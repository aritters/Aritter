using Aritter.Domain.SecurityModule.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aritter.Infra.Data.Mapping
{
	internal sealed class UserPolicyMap : EntityMap<UserPolicy>
	{
		public UserPolicyMap()
		{
			Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

			HasRequired(p => p.UserPasswordPolicy)
				.WithRequiredPrincipal(p => p.UserPolicy);
		}
	}
}
