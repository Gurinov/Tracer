using System.Runtime.Serialization;

namespace Tracer.serialization
{
    public interface ISerialization
    {
        string Serialize(Node data, XmlObjectSerializer serializer);
    }
}
