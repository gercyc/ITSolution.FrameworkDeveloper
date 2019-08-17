using System;
using System.Text;
using ITSolution.Framework.Mensagem;

namespace ITSolution.Framework.Util
{
    public class ASCIIEncodingIts 
    {

        /// <summary>
        /// Critografa uma string
        /// </summary>
        /// <param name="encoded"></param>String a ser codificada
        /// <returns></returns> A String codificada
        public static string Coded(string encoded)
        {
            string result = string.Empty;
            try
            {
                byte[] byteEncoded = System.Text.ASCIIEncoding.ASCII.GetBytes(encoded);
                result = Convert.ToBase64String(byteEncoded);
            }
            catch (DecoderFallbackException ex1)
            {
                XMessageIts.Advertencia("Falha na codificação da chave.\n"
                    + ex1.Message);

            }
            catch (FormatException ex2)
            {
                XMessageIts.Advertencia("Formato da chave a ser codificado é inválido.\n"
                    + ex2.Message);
            }
            catch (Exception)
            {
                result = string.Empty;
            }

            return result;

        }

        /// <summary>
        /// Descriptografa uma senha criptografada
        /// </summary>
        /// <param name="encoded"></param>Senha do usuário
        /// <returns></returns>
        public static string Decoded(string encoded)
        {
            try
            {

                //converter a string em bytes
                byte[] byteEncoded = Convert.FromBase64String(encoded);
                //converte os bytes em string (obtem a cadeia de string a partir dos byte)
                string stringDecoded = Encoding.ASCII.GetString(byteEncoded);

                //retorna decodificada
                return stringDecoded;

            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao descriptrografar a string \"" + encoded + "\"\n" + ex.Message);
            }
        }

    }
}
