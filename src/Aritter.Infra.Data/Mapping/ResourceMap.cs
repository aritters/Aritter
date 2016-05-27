using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class ResourceMap : EntityMap<Resource>
    {
        public ResourceMap()
        {
            Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Description)
                .HasMaxLength(100)
                .IsOptional();

            HasRequired(p => p.Module)
                .WithMany(p => p.Resources)
                .HasForeignKey(p => p.ModuleId);
        }
    }
}
