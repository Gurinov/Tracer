using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Tracer.serialization
{
    public class XmlSerialization : ISerialization
    {
        private ISerialization _serializationImplementation;
        
        public void writeToFile(Node node)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "result.xml";
            //File.WriteAllText(dir + fileName, XmlConvert.SerializeObject(node));
            
            XmlSerializer serializer = new XmlSerializer(typeof(Node));
            StreamWriter writer = new StreamWriter(dir + fileName);
            
            serializer.Serialize(writer, node);
            writer.Close();
        }

        public void writeToConsole(Node node)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Node));
            StringWriter textWriter = new StringWriter();
            serializer.Serialize(textWriter, node);
            Console.WriteLine(textWriter.ToString());
        }
    }
}