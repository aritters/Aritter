using Ritter.Domain.Seedwork.Rules.Validation;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules.Configuration
{
    public sealed class StringPropertyConfiguration<TEntity> : BasePropertyConfiguration<TEntity, string>
        where TEntity : class
    {
        public StringPropertyConfiguration(ValidationFeature<TEntity> feature, Expression<Func<TEntity, string>> expression)
            : base(feature, expression)
        {
        }

        public StringPropertyConfiguration<TEntity> IsRequired()
        {
            return IsRequired("The field is required");
        }

        public StringPropertyConfiguration<TEntity> IsRequired(string message)
        {
            Feature.AddRule(new RequiredRule<TEntity, string>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasMinLength(int minLength)
        {
            return HasMinLength(minLength, $"Length must be greater than or equal to {minLength} characters");
        }

        public StringPropertyConfiguration<TEntity> HasMinLength(int minLength, string message)
        {
            Feature.AddRule(new MinLengthRule<TEntity>(Expression, minLength, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasMaxLength(int maxLength)
        {
            return HasMaxLength(maxLength, $"Length must be less than or equal to {maxLength} characters");
        }

        public StringPropertyConfiguration<TEntity> HasMaxLength(int maxLength, string message)
        {
            Feature.AddRule(new MaxLengthRule<TEntity>(Expression, maxLength, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasPattern(string pattern)
        {
            return HasPattern(pattern, "The value does not match the pattern");
        }

        public StringPropertyConfiguration<TEntity> HasPattern(string pattern, string message)
        {
            Feature.AddRule(new PatternRule<TEntity>(Expression, pattern, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> IsCpf()
        {
            return IsCpf("The value is not a valid Cpf");
        }

        public StringPropertyConfiguration<TEntity> IsCpf(string message)
        {
            Feature.AddRule(new CpfRule<TEntity>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> IsCnpj()
        {
            return IsCnpj("The value is not a valid Cnpj");
        }

        public StringPropertyConfiguration<TEntity> IsCnpj(string message)
        {
            Feature.AddRule(new CnpjRule<TEntity>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasRange(int min, int max)
        {
            return HasRange(min, max, $"Length must be between {min} and {max} characters");
        }

        public StringPropertyConfiguration<TEntity> HasRange(int min, int max, string message)
        {
            Feature.AddRule(new StringRangeRule<TEntity>(Expression, min, max, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> IsEmail()
        {
            return IsEmail("The value is not a valid mail address");
        }

        public StringPropertyConfiguration<TEntity> IsEmail(string message)
        {
            Feature.AddRule(new EmailRule<TEntity>(Expression, message));
            return this;
        }

        public StringPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, "Custom rule does not match expectations");
        }

        public StringPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc, string message)
        {
            Feature.AddRule(new CustomRule<TEntity>(validateFunc, message));
            return this;
        }
    }
}
