using System;
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
            
            JsonSerialization json = new JsonSerialization();
            json.writeToFile(Tracer.tree);
            json.writeToConsole(Tracer.tree);
            
            XmlSerialization xml = new XmlSerialization();
            xml.writeToFile(Tracer.tree);
            xml.writeToConsole(Tracer.tree);
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