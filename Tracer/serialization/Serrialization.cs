using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Tracer.serialization
{
    public class Serrialization: ISerialization, IWriter
    {
        public string Serialize(Node data, XmlObjectSerializer serializer)
        {
            //DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Node[]));
 
            using(MemoryStream ms = new MemoryStream()) 
            {
                serializer.WriteObject(ms, new Node[]{data});
                return Encoding.Default.GetString(ms.GetBuffer());
            }
        }

        public void WriteTo(string data, Stream stream)
        {
            byte[] bytesData = System.Text.Encoding.Default.GetBytes(data);
            stream.Write(bytesData, 0, bytesData.Length);
        }
    }
}