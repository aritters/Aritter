﻿using Aritter.Domain.UnitOfWork;
using Aritter.Infra.Data.UnitOfWork;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Aritter.Infra.IoC.Modules
{
	internal sealed class UnitOfWorkModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IUnitOfWork>().To<AritterContext>().InRequestScope();
		}
	}
}
