﻿using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Common.Specs
{
    public sealed class MatchIdentitySpec<TEntity> : Specification<TEntity>
         where TEntity : class, IEntity
    {
        private readonly Guid identity;

        public MatchIdentitySpec(Guid identity)
        {
            this.identity = identity;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return (p => p.Identity == identity);
        }
    }
}
