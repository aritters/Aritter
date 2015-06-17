using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Domain.Services;
using System;
using System.Collections.Generic;

namespace Aritter.Manager.Application.Services
{
	public class ResourceAppService : AppService, IResourceAppService
	{
		private readonly IResourceDomainService resourceDomainService;

		public ResourceAppService(IResourceDomainService resourceDomainService)
		{
			if (resourceDomainService == null)
				throw new ArgumentNullException("resourceDomainService");

			this.resourceDomainService = resourceDomainService;
		}

		public IEnumerable<Resource> GetAll()
		{
			var resources = this.resourceDomainService
				.GetAll();

			return resources;
		}
	}
}