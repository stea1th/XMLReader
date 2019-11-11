using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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



    }
}
