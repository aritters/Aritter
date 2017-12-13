using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public static class ConfigurationExtensions
    {
        public static ValidationContract<TValidable> Validate<TValidable>(this ValidationContract<TValidable> contract, Action<ValidationContract<TValidable>> configAction)
            where TValidable : class, IValidable<TValidable>
        {
            if (contract is null)
                throw new ArgumentNullException(nameof(contract));

            configAction?.Invoke(contract);
            return contract;
        }

        public static ObjectPropertyConfiguration<TValidable, TProp> Property<TValidable, TProp>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, TProp>> expression)
            where TValidable : class
            where TProp : class
        {
            if (contract is null)
                throw new ArgumentNullException(nameof(contract));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new ObjectPropertyConfiguration<TValidable, TProp>(contract, expression);
        }

        public static CollectionPropertyConfiguration<TValidable> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, ICollection>> expression)
            where TValidable : class
        {
            if (contract is null)
                throw new ArgumentNullException(nameof(contract));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new CollectionPropertyConfiguration<TValidable>(contract, expression);
        }

        public static StringPropertyConfiguration<TValidable> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, string>> expression)
            where TValidable : class
        {
            if (contract is null)
                throw new ArgumentNullException(nameof(contract));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new StringPropertyConfiguration<TValidable>(contract, expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, short> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, short>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, int> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, int>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, long> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, long>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, ushort> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, ushort>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, uint> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, uint>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, ulong> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, ulong>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, byte> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, byte>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, sbyte> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, sbyte>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, float> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, float>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, decimal> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, decimal>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, double> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, double>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TValidable, DateTime> Property<TValidable>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, DateTime>> expression)
            where TValidable : class
        {
            return contract.PropertyInner(expression);
        }

        private static PrimitivePropertyConfiguration<TValidable, TProp> PropertyInner<TValidable, TProp>(this ValidationContract<TValidable> contract, Expression<Func<TValidable, TProp>> expression)
            where TValidable : class
            where TProp : struct
        {
            if (contract is null)
                throw new ArgumentNullException(nameof(contract));

            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            return new PrimitivePropertyConfiguration<TValidable, TProp>(contract, expression);
        }
    }
}
