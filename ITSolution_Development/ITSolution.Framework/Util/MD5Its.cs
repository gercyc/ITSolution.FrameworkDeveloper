using System;
using System.Security.Cryptography;
using System.Text;


namespace ITSolution.Framework.Util
{
    //https://dotnetfiddle.net/4mLWz7
    public class MD5Its  
    {
        #region Singleton

        private static MD5Its instance;

        private MD5Its()
        {
        }

        public static MD5Its Hasher
        {
            get
            {
                if (instance == null)
                    instance = new MD5Its();
                return instance;
            }
        }

        #endregion

        /// <summary>
        /// Verifica a key é corresponde ao md5
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyMD5"></param>
        /// <returns></returns>
        public bool IsMD5(string key, string keyMD5)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var md5 = Hash(key);
                if (isHash(md5Hash, keyMD5, md5))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Faz o MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GetHash(md5Hash, input);
            }
        }

        /// <summary>
        /// Obtem o hash do input informado
        /// </summary>
        private string GetHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        /// <summary>
        /// Verifica se o input corresponde ao hash
        /// </summary>
        private bool isHash(MD5 md5Hash, string input, string hash)
        {
            StringComparer compare = StringComparer.OrdinalIgnoreCase;

            if (0 == compare.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
     
        //private void teste()
        //{

        //    var senhabanco = "827ccb0eea8a706c4c34a16891f84e7b";
        //    var Senha = "12345";

        //    var value = MD5Its.Hasher.Hash(Senha);
        //    Console.WriteLine(senhabanco.Equals(value));

        //    var ComparaSenha = MD5Its.Hasher.IsMD5(Senha, senhabanco);

        //    Console.WriteLine(ComparaSenha.ToString());
        //}
    }
}
