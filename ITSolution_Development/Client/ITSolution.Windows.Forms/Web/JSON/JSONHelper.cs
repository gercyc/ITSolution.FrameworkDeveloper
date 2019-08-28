using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using ITSolution.Framework.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ITSolution.Framework.Web.JSON
{
    public static class JSONHelper
    {
        //Converte JSON em classe C# 
        //informe um link ou o proprio JSON
        //http://json2csharp.com/#


        public static string GetJSONString(string url)
        {
            try
            {

                //https://github.com/DeveloperCielo/Webservice-3.0/issues/12
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                ////https://github.com/adeniltonbs/Zeus.Net.NFe.NFCe/issues/219
                /*ServicePointManager.Expect100Continue = true;
                ServicePointManager.CheckCertificateRevocationList = false;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;*/

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                LoggerUtilIts.ShowExceptionLogs(ex);
                throw ex;
            }
        }

        public static T GetObjectFromJSONString<T>(
            string json) where T : new()
        {
            using (MemoryStream stream = new MemoryStream(
                Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(stream);
            }
        }

        public static T[] GetArrayFromJSONString<T>(
            string json) where T : new()
        {
            using (MemoryStream stream = new MemoryStream(
                Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer =
                    new DataContractJsonSerializer(typeof(T[]));
                return (T[])serializer.ReadObject(stream);
            }
        }

        //nao testei
        //https://stackoverflow.com/questions/11126242/using-jsonconvert-deserializeobject-to-deserialize-json-to-a-c-sharp-poco-class
        public static T LoadCamelCaserFromJson<T>(string response, string jsonValue) where T : class
        {
            JsonSerializerSettings serSettings = new JsonSerializerSettings();
            serSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            T outObject = JsonConvert.DeserializeObject<T>(jsonValue, serSettings);

            return outObject;
        }
    }
}
