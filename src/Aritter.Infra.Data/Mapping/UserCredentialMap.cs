using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Infra.Data.Seedwork.Mapping;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class UserCredentialMap : EntityMap<UserCredential>
    {
        public UserCredentialMap()
        {
            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(p => p.PasswordHash)
                .HasMaxLength(50);

            HasRequired(p => p.User)
                .WithRequiredDependent(p => p.Credential);
        }
    }
}
