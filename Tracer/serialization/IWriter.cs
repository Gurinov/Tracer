using System.IO;

namespace Tracer.serialization
{
    public interface IWriter
    {
        void WriteTo(string data, Stream stream);
    }
}