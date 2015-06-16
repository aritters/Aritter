using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Manager.Infrastructure.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static bool IsEmpty(this ICollection input)
		{
			return input == null || input.Count == 0;
		}

		public static bool IsEmpty<T>(this ICollection<T> input)
		{
			return input == null || !input.Any();
		}

		#endregion Methods
	}
}