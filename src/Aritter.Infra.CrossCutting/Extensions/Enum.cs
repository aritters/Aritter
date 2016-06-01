using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.ComponentModel;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        #region Methods

        public static T[] GetEnumStructure<T, TEnum>(this Type enumType, Func<TEnum, string, T> parseToInstance)
        {
            Guard.IsNotNull(enumType, nameof(enumType));
            Guard.IsNotNull(parseToInstance, nameof(parseToInstance));

            var names = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType);

            var result = new T[values.Length];

            for (var i = 0; i < values.Length; i++)
            {
                result[i] = parseToInstance((TEnum)values.GetValue(i), (string)names.GetValue(i));
            }

            return result;
        }

        public static T ToAmbientValue<T>(this Enum value, T defaultValue)
        {
            var attribute = value.GetType().GetAttributeFromEnumType<AmbientValueAttribute>(value);
            return attribute == null ? defaultValue : (T)attribute.Value;
        }

        public static T ToAmbientValue<T>(this Enum value)
        {
            return ToAmbientValue(value, default(T));
        }

        public static string ToDescription(this Enum value)
        {
            return ToDescription(value, string.Empty);
        }

        public static string ToDescription(this Enum value, string defaultValue)
        {
            var attribute = value.GetType().GetAttributeFromEnumType<DescriptionAttribute>(value);
            return attribute == null ? defaultValue : attribute.Description;
        }

        #endregion Methods
    }
}