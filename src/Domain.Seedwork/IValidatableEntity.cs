namespace Ritter.Domain.Seedwork
{
    public interface IValidatableEntity<TEntity> : IEntity
        where TEntity : class
    {
    }
}
