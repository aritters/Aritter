﻿using System;
using System.Linq.Expressions;


namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class CnpjRule<T> : GenericRule<T, string>
    {
        public CnpjRule(Expression<Func<T, string>> expression) : base(expression)
        {
        }

        public CnpjRule(Func<T, string> provider) : base(provider)
        {
        }

        public override bool Validate(Func<T> source)
        {
            return ValidaCnpj(provider(source()));
        }

        public bool ValidaCnpj(string cnpjValidar)
        {
            string cnpj = cnpjValidar;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);

            resto = resto < 2 ? 0 : 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);

            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}
