using System;

namespace ITSolution.Framework.Util
{
    /// <summary>
    /// Extensão de metodo para String
    /// </summary>
    public static class StringExtends
    {
        //http://pt.stackoverflow.com/questions/82141/transformar-a-primeira-letra-de-uma-string-em-mai%C3%BAscula

        /// <summary>
        /// Remove os caracteres da string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string RemoverLastCharCount(this string input, int count)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("String informada nula ou vazia.");

            else if (input.Length < count)
                throw new IndexOutOfRangeException("Tentativa de remoção de caracteres fora do índice.");


            return input.Remove(input.Length - count, count);
        }
        /// <summary>
        /// Converter o primeira caracter para maiusculo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstCharToLower(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("String informada nula ou vazia.");
            return input.Length > 1 ? char.ToLower(input[0]) + input.Substring(1) : input.ToLower();
        }

  
        /// <summary>
        /// Converte o ultimo caracter para minusculo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string LastCharToLower(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("String informada nula ou vazia.");

            return input.Length > 1 ? input.Substring(0) + char.ToLower(input[input.Length - 1]) : input.ToLower();
        }

        /// <summary>
        /// Converter o primeira caracter para maiusculo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("String informada nula ou vazia.");
            return input.Length > 1 ? char.ToLower(input[0]) + input.Substring(1) : input.ToUpper();
        }

        /// <summary>
        /// Converte o ultimo caracter para maiusculo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string LastCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("String informada nula ou vazia.");

            return input.Length > 1 ? input.Substring(0) + char.ToUpper(input[input.Length - 1]) : input.ToLower();
        }




        /// <summary>
        /// Um 's' eh adicionado na primeira ocorrencia de uma letra maiuscula
        /// </summary>
        /// <param name="input"></param>String 
        /// <returns></returns>String alterada
        public static string PluralizeStringOnUpperCase(this string input)
        {

            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("String informada nula ou vazia.");

            if (input.Length <= 1)
            {
                return input;
            }
            //percorre a string
            for (int i = 1; i < input.Length; i++)
            {
                //pega o caracter da string
                var c = input.Substring(i, 1);

                var cUpper = c.ToUpper();

                if (c.Equals(cUpper))
                {
                    //quebra a string na ocorrencia do caracter q esta em maisculo
                    var split = input.Split(c.ToCharArray());
                    string newString = split[0] + "s";
                    //add o caracter que foi removido no split e o restante da string
                    string word = c + split[1];

                    newString += word;
                    return newString;
                }

            }
            return input;
        }

    }
}
