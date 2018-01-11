using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class PatternRule<TValidable> : PropertyRule<TValidable, string> where TValidable : class, IValidable
    {
        private readonly string pattern;

        public PatternRule(Expression<Func<TValidable, string>> expression, string pattern) : this(expression, pattern, null) { }

        public PatternRule(Expression<Func<TValidable, string>> expression, string pattern, string message) : base(expression, message)
        {
            this.pattern = pattern;
        }

        public override bool Validate(TValidable entity)
        {
            return Regex.IsMatch(Compile(entity), pattern);
        }
    }
}