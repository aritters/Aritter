﻿using SimpleInjector;
using System.Linq;
using System.Reflection;

namespace Aritter.Manager.Infrastructure.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static void RegisterAsDefaultInterfaces<TService>(this Container container)
		{
			RegisterAsDefaultInterfaces<TService>(container, Lifestyle.Transient);
		}

		public static void RegisterAsDefaultInterfaces<TService>(this Container container, Lifestyle lifestyle)
		{
			RegisterAsDefaultInterfaces<TService>(container, null, lifestyle);
		}

		public static void RegisterAsDefaultInterfaces<TService>(this Container container, Assembly assembly)
		{
			RegisterAsDefaultInterfaces<TService>(container, assembly, Lifestyle.Transient);
		}

		public static void RegisterAsDefaultInterfaces<TService>(this Container container, Assembly assembly, Lifestyle lifestyle)
		{
			var typeAssembly = assembly ?? typeof(TService).Assembly;
			var registrations = typeAssembly.GetExportedTypes()
				.Where(p =>
					!p.IsAbstract
					&& typeof(TService).IsAssignableFrom(p)
					&& p.GetInterfaces().Any())
				.Select(p =>
					new
					{
						Service = p.GetInterfaces().LastOrDefault(),
						Implementation = p
					})
				.ToList();
			registrations.ForEach(registration =>
			{
				if (registration.Service != null)
					container.Register(registration.Service, registration.Implementation, lifestyle);
			});
		}

		#endregion Methods
	}
}
