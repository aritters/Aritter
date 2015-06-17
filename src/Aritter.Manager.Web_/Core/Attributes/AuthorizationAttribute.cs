using Aritter.Manager.Application.Services;
using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Configuration;
using Aritter.Manager.Infrastructure.Extensions;
using Aritter.Manager.Infrastructure.Injection;
using Aritter.Manager.Web.Core.Aggregates;
using Aritter.Manager.Web.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aritter.Manager.Web.Core.Attributes
{
	public class AuthorizationAttribute : AuthorizeAttribute
	{
		#region Members

		private readonly IUserAppService userAppService;
		private readonly int currentUser = 0;

		#endregion

		#region Constructors

		public AuthorizationAttribute()
		{
			this.userAppService = DependencyProvider.Instance.GetInstance<IUserAppService>();

			this.currentUser = ApplicationSettings.CurrentUser.GetId();
		}

		#endregion

		#region Methods

		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (!this.AuthorizeCore(filterContext.HttpContext))
			{
				base.OnAuthorization(filterContext);
				return;
			}

			var route = filterContext.GetRoute();
			this.CheckAuthorization(filterContext, route);

			if (this.CheckChangePasswordRequired(route))
			{
				var redirectUrl = new UrlHelper(filterContext.RequestContext).Action("ChangePassword", "Account", new { returnUrl = route.CurrentPath });
				filterContext.Result = new RedirectResult(redirectUrl);
			}
		}

		private bool CheckChangePasswordRequired(RouteData route)
		{
			var changePasswordRequired = this.userAppService.CheckChangePasswordRequired(this.currentUser);

			return changePasswordRequired
				&& route.RequestArea == null
				&& route.RequestController == "Account"
				&& route.RequestAction == "ChangePassword";
		}

		private void CheckAuthorization(AuthorizationContext filterContext, RouteData route)
		{
			if (route.RequestActionAllowAnonymous)
				return;

			var actionRules = this.GetActionRules(filterContext);

			if (!actionRules.Any())
				return;

			if (!this.HasAuthorization(route.RequestArea, route.RequestAction, route.RequestController, actionRules))
				throw new HttpException((int)HttpStatusCode.NotFound, "Not found");
		}

		private bool HasAuthorization(string area, string action, string controller, IEnumerable<Rule> actionRules)
		{
			if (string.IsNullOrEmpty(action) && string.IsNullOrEmpty(controller))
				return true;

			var userRules = this.userAppService
				.GetRules(this.currentUser, area, controller, action);

			if (userRules.Contains(Rule.All) || userRules.Intersect(actionRules).Any())
				return true;

			return false;
		}

		private ICollection<Rule> GetActionRules(AuthorizationContext filterContext)
		{
			var requiredRules = filterContext.ActionDescriptor.GetCustomAttributes(typeof(RequiredRuleAttribute), false).Cast<RequiredRuleAttribute>();

			return requiredRules
				.SelectMany(p => p.Rules)
				.Distinct()
				.ToList();
		}

		#endregion
	}
}