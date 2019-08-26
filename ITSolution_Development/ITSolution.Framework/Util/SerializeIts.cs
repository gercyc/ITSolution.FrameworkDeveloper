using ITSolution.Framework.Arquivos;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ITSolution.Framework.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class SerializeIts
    {
        /// <summary>
        /// Deserializa um objeto
        /// </summary>
        /// <param name="bytes"></param>bytes
        /// <returns></returns>Objeto deserializado
        public static T DeserializeObject<T>(byte[] bytes) where T : class
        {
            try
            {
                Object obj = new Object();
                var binaryFormatter = new BinaryFormatter();
                using (MemoryStream memoryStream = new MemoryStream())
                {

                    memoryStream.Write(bytes, 0, bytes.Length);
                    memoryStream.Position = 0;
                    obj = binaryFormatter.Deserialize(memoryStream);
                    return obj as T;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Deserializa um objeto
        /// </summary>
        /// <param name="bytes"></param>bytes
        /// <returns></returns>Objeto deserializado
        public static object DeserializeObject(byte[] bytes)
        {
            if (bytes != null)
            {
                Object obj = new Object();
                var binaryFormatter = new BinaryFormatter();
                using (MemoryStream memoryStream = new MemoryStream())
                {

                    memoryStream.Write(bytes, 0, bytes.Length);
                    memoryStream.Position = 0;
                    obj = binaryFormatter.Deserialize(memoryStream);
                    return obj;
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Serializa um objeto
        /// </summary>
        /// <param name="obj"></param>objeto a ser serializado
        /// <returns></returns>bytes
        public static byte[] SerializeObject(Object obj)
        {
            if (obj != null)
            {
                var binaryFormatter = new BinaryFormatter();

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, obj);

                    return memoryStream.GetBuffer();
                }
            }
            else
                return null;

        }
    }
}
