using Ritter.Domain.Seedwork.Validation.Caching;
using Ritter.Domain.Seedwork.Validation.Fluent;
using Ritter.Infra.Crosscutting;
using System;

namespace Ritter.Domain.Seedwork.Validation
{
    public static class ValidationContractFactory
    {
        public static ValidationContract EnsureContract(Type type, IValidationContractCacheProvider cachingProvider)
        {
            Ensure.Argument.NotNull(cachingProvider, nameof(cachingProvider));

            string contractKey = $"{typeof(ValidationContract<>).Name}[{type.Name}]";
            ValidationContract contract = cachingProvider.GetItem(contractKey);

            if (contract is null)
            {
                contract = CreateContract(type);
                cachingProvider.AddItem(contractKey, contract);
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
