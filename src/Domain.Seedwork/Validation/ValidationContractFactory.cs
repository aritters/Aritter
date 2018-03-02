using System;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Infra.Crosscutting;

namespace Domain.Seedwork.Validation
{
    public static class ValidationContractFactory
    {
        public static ValidationContract EnsureContract(Type type, IValidationContractCachingProvider cachingProvider)
        {
            Ensure.Argument.NotNull(cachingProvider, nameof(cachingProvider));

            ValidationContract contract = cachingProvider.GetItem(type);

            if (contract is null)
            {
                contract = CreateContract(type);
                cachingProvider.AddItem(contract);
            }

            return contract;
        }

        private static ValidationContract CreateContract(Type type)
        {
            Type contractType = typeof(ValidationContract<>);
            Type genericType = contractType.MakeGenericType(new Type[] { type });
            ValidationContract contract = (ValidationContract)Activator.CreateInstance(genericType);

            return contract;
        }
    }
}