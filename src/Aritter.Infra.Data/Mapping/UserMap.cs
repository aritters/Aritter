using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Seedwork.Mapping;
using Aritter.Infra.Data.SeedWork.Extensions;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class UserMap : EntityMap<User>
    {
        public UserMap()
        {
            Property(p => p.UserName)
                .HasMaxLength(100)
                .HasUniqueIndex("UQ_UserUsername")
                .IsRequired();

            Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.LastName)
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.Email)
                .HasMaxLength(255)
                .HasUniqueIndex("UQ_UserMailAddress");

            Property(p => p.MustChangePassword)
                .IsRequired();

            HasOptional(p => p.UserPolicy)
                .WithOptionalPrincipal(p => p.User);
        }
    }
}
