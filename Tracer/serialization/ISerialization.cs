namespace Tracer.serialization
{
    public interface ISerialization
    {
        void writeToFile(Node node);
        void writeToConsole(Node node);
    }
}
