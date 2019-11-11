using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace XMLReaderConsole.Helpers
{
    internal static class ParseHelpers
    {

        //private static JavaScriptSerializer _json;
        //private static JavaScriptSerializer JSON { get { return _json ?? (_json = new JavaScriptSerializer()); } }
        public static Stream ToMemoryStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static Stream ToFileStream()
        {
            return new FileStream("payload3.xml", FileMode.Create, FileAccess.Write);
            
        }

        public static T ParseXML<T>(this string @this) where T : class
        {
            var reader = XmlReader.Create(@this.Trim().ToMemoryStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }

        public static T ParseJSON<T>(this string @this) where T : class
        {
            return JsonConvert.DeserializeObject<T>(@this);
        }

        public static string SerializeToJSON<T>(this T @obj) where T : class
        {
            return JsonConvert.SerializeObject(@obj);
        }

        public static void SerializeToXml<T>(this T @obj) where T : class
        {
            new XmlSerializer(typeof(T)).Serialize(ToFileStream(), @obj);
        }
    }
}
