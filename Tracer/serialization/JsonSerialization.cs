using System;
using System.IO;
using Newtonsoft.Json;

namespace Tracer.serialization
{
    public class JsonSerialization : ISerialization
    {
        public void writeToFile(Node node)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "result.json";
            File.WriteAllText(dir + fileName, JsonConvert.SerializeObject(node));
        }

        public void writeToConsole(Node node)
        {
            Console.WriteLine(JsonConvert.SerializeObject(node));
        }
       
    }
}