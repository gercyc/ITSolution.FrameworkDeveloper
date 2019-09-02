using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ITSolution.Framework.Core.BaseClasses
{
    public static class StringUtilIts
    {

        /// <summary>
        /// Verifica se a string é um digito válido
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static bool IsLetterOrDigit(this string texto)
        {
            if (texto.StartsWith(" "))
                return false;
            else if (texto.Where(c => char.IsLetterOrDigit(c)).Count() > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifica se a string contém letras
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static bool IsContainsLetters(this string texto)
        {
            if (texto.Where(c => char.IsLetter(c)).Count() > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifica se a string contém números
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static bool IsContainsNumber(this string texto)
        {
            if (texto.Where(c => char.IsNumber(c)).Count() > 0)
                return true;
            else
                return false;
        }

        ///Validacao de CPF e CNPJ
        ///http://www.devmedia.com.br/validacao-de-cpf-e-cnpj/3950

        /// <summary>
        /// Elimina caracteres especiais da string. Serão aceitos apenas digitos
        /// </summary>
        /// <param name="str_"></param>
        /// <returns></returns>
        public static string FixString(this string str_)
        {
            string strClean = "";
            if (string.IsNullOrWhiteSpace(str_))
                return strClean;
            for (int i = 0; i < str_.Length; i++)
            {
                var str = str_.Substring(i, 1);

                if (char.IsDigit(str.ToCharArray()[0]))
                {
                    strClean += str;

                }
            }
            return strClean;
        }

        /// <summary>
        /// Realiza a validação do CPF
        /// </summary>
        public static bool IsCpf(string CPF)
        {             
            CPF = FixString(CPF);

            if (CPF.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (CPF[i] != CPF[0])
                    igual = false;


            if (igual || CPF == "12345678909")
                return false;


            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(CPF[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;

        }

        public static string GetStringFromBytes(byte[] bytes)
        {
            try
            {
                MemoryStream stream = new MemoryStream(bytes);

                // convert stream to string
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao obter string dos bytes =>\n=>" + ex.Message);
            }

        }

        public static string GetStringFromStream(MemoryStream stream)
        {
            try
            {

                // convert stream to string
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao obter string do MemoryStream =>\n=>" + ex.Message);
            }
        }

        /// <summary>
        /// Realiza a validação do CNPJ
        /// </summary>
        public static bool IsCnpj(string CNPJ)
        {
            CNPJ = FixString(CNPJ);

            int[] digitos, soma, resultado;

            int nrDig;

            string ftmt;

            bool[] CNPJOk;


            ftmt = "6543298765432";

            digitos = new int[14];

            soma = new int[2];

            soma[0] = 0;

            soma[1] = 0;

            resultado = new int[2];

            resultado[0] = 0;

            resultado[1] = 0;

            CNPJOk = new bool[2];

            CNPJOk[0] = false;

            CNPJOk[1] = false;



            try
            {

                for (nrDig = 0; nrDig < 14; nrDig++)
                {

                    digitos[nrDig] = int.Parse(

                        CNPJ.Substring(nrDig, 1));

                    if (nrDig <= 11)

                        soma[0] += (digitos[nrDig] *

                          int.Parse(ftmt.Substring(

                          nrDig + 1, 1)));

                    if (nrDig <= 12)

                        soma[1] += (digitos[nrDig] *

                          int.Parse(ftmt.Substring(

                          nrDig, 1)));

                }



                for (nrDig = 0; nrDig < 2; nrDig++)
                {

                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (

                         resultado[nrDig] == 1))

                        CNPJOk[nrDig] = (

                        digitos[12 + nrDig] == 0);

                    else

                        CNPJOk[nrDig] = (

                        digitos[12 + nrDig] == (

                        11 - resultado[nrDig]));

                }

                return (CNPJOk[0] && CNPJOk[1]);

            }

            catch
            {

                return false;

            }

        }

        public static bool IsEmail(string Valor)
        {
            if (string.IsNullOrEmpty(Valor))
            {
                return true;
            }
            bool Valido = false;
            Regex regEx = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]
              *[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$", RegexOptions.IgnoreCase);
            Valido = regEx.IsMatch(Valor);
            return Valido;
        }

        /// <summary>
        /// Corrigi o numero de virgulas
        /// Retorna a string com uma virgula formatada 
        /// Ex : 123,4,5 Saída: 123,45
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static String FixDecimal(string text)
        {

            int comma = 0;
            string newString = "";
            for (int i = 0; i < text.Length; i++)
            {
                // Get first characters.
                string sub = text.Substring(i, 1);

                if (comma > 0 && sub.Equals(","))
                    continue;
                else if (sub.Equals(","))
                    comma++;
                else
                    newString += sub;
            }
            return newString;
        }

        /// <summary>
        /// Converte a cadeia de caracteres na máscara de CPF ou CNPJ, conforme o tamanho.
        /// 11 - CPF --> 000.000.000-00 | 14 - CNPJ --> 00.000.000/0000-00
        /// </summary>
        /// <param name="TValue"></param>
        /// <returns></returns>
        public static string ToCpfCnpj(Object TValue)
        {
            if (TValue != null)
            {
                string formatado = TValue.ToString();

                formatado = FixString(formatado);

                if (TValue.ToString().Length == 11)
                {
                    formatado = Convert.ToUInt64(formatado).ToString(@"000\.000\.000\-00");
                    return formatado;
                }
                else if (TValue.ToString().Length == 14)
                {
                    formatado = Convert.ToUInt64(formatado).ToString(@"00\.000\.000\/0000\-00");
                    return formatado;
                }
                else
                    return formatado;
            }
            else
                return String.Empty;
        }

        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

    }
}
