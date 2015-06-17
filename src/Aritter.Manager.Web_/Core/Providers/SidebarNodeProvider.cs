using Aritter.Manager.Application.Services;
using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Configuration;
using Aritter.Manager.Infrastructure.Extensions;
using Aritter.Manager.Infrastructure.Injection;
using MvcSiteMapProvider;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Manager.Web.Core.Providers
{
	public class SidebarNodeProvider : DynamicNodeProviderBase
	{
		private readonly IResourceAppService resourceAppService;
		private readonly IUserAppService userAppService;

		private readonly int currentUser;

		public SidebarNodeProvider()
		{
			this.resourceAppService = DependencyProvider.Instance.GetInstance<IResourceAppService>();
			this.userAppService = DependencyProvider.Instance.GetInstance<IUserAppService>();

			this.currentUser = ApplicationSettings.CurrentUser.GetId();
		}

		public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
		{
			var resources = this.resourceAppService.GetAll();
			var permissions = this.userAppService.GetMenus(this.currentUser);

			var dynamicNodes = new List<DynamicNode>();

			foreach (var resource in resources.Where(p => p.Type == ResourceType.Menu))
			{
				var parentNode = new DynamicNode
				{
					Clickable = false,
					Description = resource.Description,
					ImageUrl = resource.Icon,
					Key = resource.Id.ToString(),
					Title = resource.Title,
					Action = null,
					Controller = null,
					Area = null,
					Order = resource.Order,
					ParentKey = null
				};

				var children = this.GetChildrenNodes(resource.Id, resources, permissions);

				if (children.Any())
				{
					dynamicNodes.Add(parentNode);
					dynamicNodes.AddRange(children);
				}
			}

			return dynamicNodes;
		}

		private IEnumerable<DynamicNode> GetChildrenNodes(int parentId, IEnumerable<Resource> resources, IEnumerable<Resource> permissions)
		{
			var children = new List<DynamicNode>();

			foreach (var child in resources.Where(p => p.ParentId == parentId && permissions.Any(x => x.Id == p.Id)))
			{
				var childNode = new DynamicNode
				{
					Clickable = !resources.Any(p => p.ParentId == child.Id && permissions.Any(x => x.Id == p.Id)),
					Description = child.Description,
					ImageUrl = child.Icon,
					Key = child.Id.ToString(),
					Title = child.Title,
					Action = child.Action,
					Controller = child.Controller,
					Area = child.Area,
					Order = child.Order,
					ParentKey = parentId.ToString()
				};

				children.Add(childNode);

				if (resources.Any(p => p.ParentId == child.Id))
				{
					var childrenNodes = this.GetChildrenNodes(child.Id, resources, permissions);

					if (childrenNodes.Any())
						children.AddRange(childrenNodes);
				}
			}

			return children;
		}
	}
}