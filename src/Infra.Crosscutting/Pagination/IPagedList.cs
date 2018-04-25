using System.Collections;
using System.Collections.Generic;

namespace Ritter.Infra.Crosscutting.Pagination
{
    public interface IPagedList<T> : IList<T>, IList, IReadOnlyList<T>
    {
        int TotalCount { get; }
        int TotalPage { get; }
    }
}
