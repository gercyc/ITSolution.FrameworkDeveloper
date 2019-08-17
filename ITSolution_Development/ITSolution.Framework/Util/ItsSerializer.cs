using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class ItsSerializer
    {
        /// <summary>
        /// Deserializa um objeto
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(byte[] bytes) where T : class
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
                    return obj as T;
                }
            }
            else
                return null;
        }

        public static Object DeserializeObjectO(byte[] bytes)
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
