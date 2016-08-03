﻿using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specifications;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public interface IUserRepository : IRepository<User>
    {
        ICollection<UserAssignment> GetAuthorizedAssigns(ISpecification<UserAssignment> specification);
    }
}
