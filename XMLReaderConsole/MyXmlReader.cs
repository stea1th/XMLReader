using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using XMLReaderConsole.Helpers;

namespace XMLReaderConsole
{
    class MyXmlReader
    {

        public void TestXmlReader()
        {
            var document = Properties.Resources.payload1;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(document);
            XmlElement rootElement = xmlDocument.DocumentElement;
            Console.WriteLine(rootElement.Name);
            XmlNodeList nodes = xmlDocument.GetElementsByTagName("Group");
            foreach(XmlNode xmlNode in nodes)
            {
                Console.WriteLine(xmlNode.Attributes["name"].Value);
            }
            
            
            Console.ReadKey();
        }

        public static void TestXPath()
        {
            var document = Properties.Resources.payload1;
            var xdoc = XDocument.Load(document.ToMemoryStream());
            var xName = XName.Get("Group", "http://javaops.ru");
            var e = xdoc.Element(xName);
            Console.WriteLine(e?.Attribute("name"));
            Console.ReadKey();


        }



    }
}
