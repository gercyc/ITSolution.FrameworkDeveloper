using System.Xml;
using System.Xml.Linq;

namespace ITSolution.Framework.Core.BaseClasses
{
    public class XmlUtil
    {
        public static XmlDocument ReadXml(string xmlFile)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlFile);
                return xml;

            }
            catch (XmlException )
            {
                return null;
            }
        }

        public static XElement ReadXmlElements(string xmlFile)
        {
            try
            {
                XElement xml = XElement.Load(xmlFile);
                return xml;
            }
            catch (XmlException)
            {
                return null;
            }
        }
    }
}
