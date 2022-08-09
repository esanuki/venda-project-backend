using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVenda.Core.DomainObjects
{
    public class CpfValidacao
    {
        public const int TamanhoCpf = 11;

        public static bool Validate(string cpf)
        {
            var cpfNumeros = Utils.OnlyNumbers(cpf);

            if (!LengthValidate(cpfNumeros)) return false;
            return !HaveDigitsReplicate(cpfNumeros) && HaveDigitsValidate(cpfNumeros);
        }

        private static bool LengthValidate(string valor)
        {
            return valor.Length == TamanhoCpf;
        }

        private static bool HaveDigitsReplicate(string valor)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
            return invalidNumbers.Contains(valor);
        }

        private static bool HaveDigitsValidate(string valor)
        {
            var number = valor.Substring(0, TamanhoCpf - 2);
            var digitoVerificador = new DigitsVerify(number)
                .WithMultipleAt(2, 11)
                .Replace("0", 10, 11);
            var firstDigit = digitoVerificador.CalculateDigits();
            digitoVerificador.AddDigits(firstDigit);
            var secondDigit = digitoVerificador.CalculateDigits();

            return string.Concat(firstDigit, secondDigit) == valor.Substring(TamanhoCpf - 2, 2);
        }
    }

    public class CnpjValidacao
    {
        public const int TamanhoCnpj = 14;

        public static bool Validate(string cpnj)
        {
            var cnpjNumeros = Utils.OnlyNumbers(cpnj);

            if (!LengthValidate(cnpjNumeros)) return false;
            return !HaveDigitsReplicate(cnpjNumeros) && HaveDigitsValidate(cnpjNumeros);
        }

        private static bool LengthValidate(string valor)
        {
            return valor.Length == TamanhoCnpj;
        }

        private static bool HaveDigitsReplicate(string valor)
        {
            string[] invalidNumbers =
            {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
            return invalidNumbers.Contains(valor);
        }

        private static bool HaveDigitsValidate(string valor)
        {
            var number = valor.Substring(0, TamanhoCnpj - 2);

            var digitoVerificador = new DigitsVerify(number)
                .WithMultipleAt(2, 9)
                .Replace("0", 10, 11);
            var firstDigit = digitoVerificador.CalculateDigits();
            digitoVerificador.AddDigits(firstDigit);
            var secondDigit = digitoVerificador.CalculateDigits();

            return string.Concat(firstDigit, secondDigit) == valor.Substring(TamanhoCnpj - 2, 2);
        }
    }

    public class DigitsVerify
    {
        private string _numero;
        private const int Modulo = 11;
        private readonly List<int> _multiplicadores = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _substituicoes = new Dictionary<int, string>();
        private bool _complementarDoModulo = true;

        public DigitsVerify(string numero)
        {
            _numero = numero;
        }

        public DigitsVerify WithMultipleAt(int primeiroMultiplicador, int ultimoMultiplicador)
        {
            _multiplicadores.Clear();
            for (var i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
                _multiplicadores.Add(i);

            return this;
        }

        public DigitsVerify Replace(string substituto, params int[] digitos)
        {
            foreach (var i in digitos)
            {
                _substituicoes[i] = substituto;
            }
            return this;
        }

        public void AddDigits(string digito)
        {
            _numero = string.Concat(_numero, digito);
        }

        public string CalculateDigits()
        {
            return !(_numero.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var soma = 0;
            for (int i = _numero.Length - 1, m = 0; i >= 0; i--)
            {
                var produto = (int)char.GetNumericValue(_numero[i]) * _multiplicadores[m];
                soma += produto;

                if (++m >= _multiplicadores.Count) m = 0;
            }

            var mod = (soma % Modulo);
            var resultado = _complementarDoModulo ? Modulo - mod : mod;

            return _substituicoes.ContainsKey(resultado) ? _substituicoes[resultado] : resultado.ToString();
        }
    }

    public class Utils
    {
        public static string OnlyNumbers(string valor)
        {
            var onlyNumber = "";
            foreach (var s in valor)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}
