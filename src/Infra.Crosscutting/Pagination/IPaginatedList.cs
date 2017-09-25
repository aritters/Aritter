﻿using System.Collections;
using System.Collections.Generic;

namespace Ritter.Infra.Crosscutting.Pagination
{
    public interface IPaginatedList<T> : IList<T>, IList, IReadOnlyList<T>
    {
        int TotalCount { get; }
        int PageCount { get; }
    }
}