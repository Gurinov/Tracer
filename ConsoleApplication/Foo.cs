using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Tracer.serialization;

namespace Tracer
{
    public class Foo
    {
        private Bar _bar;
        private Tracer _tracer;
​
        public static void Main(string[] args)
        {
            Tracer tracer = new Tracer();
            Foo foo = new Foo(tracer);
            foo.MyMethod(10);
            string path = @"c:\Users\gurin\Desktop\";
            Serrialization ser = new Serrialization();
            ser.WriteTo(ser.Serialize(Tracer.tree, new DataContractJsonSerializer(typeof(Node[]))),Console.OpenStandardOutput());
            ser.WriteTo(ser.Serialize(Tracer.tree, new DataContractSerializer(typeof(Node[]))),Console.OpenStandardOutput());
            ser.WriteTo(ser.Serialize(Tracer.tree, new DataContractJsonSerializer(typeof(Node[]))), new FileStream(path + "data.json", FileMode.OpenOrCreate));
            ser.WriteTo(ser.Serialize(Tracer.tree, new DataContractSerializer(typeof(Node[]))), new FileStream(path + "data.xml", FileMode.OpenOrCreate));
        }
        
        internal Foo(Tracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }
    
        public void MyMethod(int i)
        {
            _tracer.StartTrace();
            //_bar.InnerMethod();
            if(i > 0) 
                MyMethod(i-1);
            _tracer.StopTrace();
        }
        
        public void MyMethod2()
        {
            _tracer.StartTrace();
            //Thread.Sleep(200);
            _bar.InnerMethod2();
            _bar.InnerMethod3();
            for (int i = 0; i < 99999; i++)
            {
                Console.Write("");
              
            }
            _tracer.StopTrace();
        }
    }
}