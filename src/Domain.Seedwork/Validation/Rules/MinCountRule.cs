using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class MinCountRule<TValidable> : PropertyRule<TValidable, ICollection> where TValidable : class, IValidable
    {
        private readonly int minCount;

        public MinCountRule(Expression<Func<TValidable, ICollection>> expression, int minCount) : this(expression, minCount, null) { }

        public MinCountRule(Expression<Func<TValidable, ICollection>> expression, int minCount, string message) : base(expression, message)
        {
            this.minCount = minCount;
        }

        public override bool Validate(TValidable entity)
        {
            ICollection collection = Compile(entity);

            if (collection is null && minCount > 0)
                return false;

            return collection.Count >= minCount;
        }
    }
}