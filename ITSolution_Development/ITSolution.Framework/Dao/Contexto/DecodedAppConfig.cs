using ITSolution.Framework.Entities;
using ITSolution.Framework.Util;
using System;

//Padrão Singleton
namespace ITSolution.Framework.Dao.Contexto
{
    public sealed class DecodedAppConfig
    {
      
        private DecodedAppConfig()
        {
        }

        private static DecodedAppConfig _instance;

        public static DecodedAppConfig Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DecodedAppConfig();

                return _instance;
            }
        }
 

        /// <summary>
        /// Descriptografa o AppConfig informado.
        ///     Somente a senha é decifrada.
        /// </summary>
        /// <param name="appConfig"></param>
        public void AppConfig(AppConfigIts appConfig)
        {
            //appConfig.ServerName = EncryptionUtil.Decoded(appConfig.ServerName);
            //appConfig.Database = EncryptionUtil.Decoded(appConfig.Database);
            //appConfig.User = EncryptionUtil.Decoded(appConfig.User);

            try
            {
                //descodifica
                string uncoded = ASCIIEncodingIts.Decoded(appConfig.Password);
                //codifica
                string coded = ASCIIEncodingIts.Coded(uncoded);

                //se recebida esta igual a senha criptograda
                if (appConfig.Password.Equals(coded))
                    //tava criptografada ok
                    appConfig.Password = uncoded;

                //nao estava criptografada use a deixa a pw quieta
            }
            catch(Exception)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Descriptografia desnecessária");
                Console.ForegroundColor = ConsoleColor.Black;
            }

        }
    }
}
