using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLReaderConsole.Entities;
using XMLReaderConsole.Helpers;

namespace XMLReaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyXmlReader reader = new MyXmlReader();
            //reader.TestXmlReader();
            var document = Properties.Resources.payload1;
            var payload = document.ParseXML<Payload>();
            foreach(PayloadProject project in payload.Projects) {
                //project.Group.
                Console.WriteLine(project.name);
            }
            Console.WriteLine(payload.SerializeToJSON());
            PayloadCity city = new PayloadCity
            {
                id = "vsg",
                Value = "Visaginas"
            };
            var cities = payload.Cities.ToList();
            cities.Add(city);
            payload.Cities = cities.ToArray();
            //ParseHelpers.SerializeToXml<PayloadCity>(city);
            payload.SerializeToXml<Payload>();
            foreach (PayloadCity city1 in payload.Cities)
            {
                //project.Group.
                Console.WriteLine(city1.Value);
            }

            Console.ReadKey();

        }
    }
}
