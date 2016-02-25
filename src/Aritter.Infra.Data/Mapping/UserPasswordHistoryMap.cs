using Aritter.Domain.Aggregates.Security;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class UserPasswordHistoryMap : EntityMap<UserPassword>
    {
        public UserPasswordHistoryMap()
        {
            Property(p => p.PasswordHash)
                .HasMaxLength(50);

            HasRequired(p => p.User)
                .WithMany(p => p.PasswordHistory)
                .HasForeignKey(p => p.UserId);
        }
    }
}
