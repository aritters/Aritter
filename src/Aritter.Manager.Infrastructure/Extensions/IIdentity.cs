﻿using System.Security.Principal;

namespace Aritter.Manager.Infrastructure.Extensions
{
	public static partial class ExtensionManager
	{
		public static int GetId(this IIdentity identity)
		{
			int id = 0;
			int.TryParse(identity.Name, out id);
			return id;
		}
	}
}