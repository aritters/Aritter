using Ritter.Infra.Crosscutting;

namespace Ritter.Infra.Http.Results.Pagging
{
    public static class PagedResult
    {
        public static PagedResult<T> FromPagedCollection<T>(IPagedCollection<T> source)
            => new PagedResult<T>(source);
    }
}