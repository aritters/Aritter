using System;
using System.Collections.Generic;

namespace Aritter.Manager.Infrastructure.Extensions
{
	public static partial class ExtensionManager
	{
		#region Fields

		private static readonly string nullabeTypeName = typeof(Nullable<>).Name;

		#endregion Fields

		#region Methods

		public static bool IsEnumerable(this Type type)
		{
			return type == null
				? false
				: type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
		}

		public static bool IsList(this Type type)
		{
			return type.IsEnumerable();
		}

		public static bool IsNullable(this Type type)
		{
			return type.Name == nullabeTypeName;
		}

		#endregion Methods
	}
}