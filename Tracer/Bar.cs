using System;
using System.Threading;

namespace Tracer
{
    public class Bar
    {
        private Tracer _tracer;
​
        internal Bar(Tracer tracer)
        {
            _tracer = tracer;
        }
    
        public void InnerMethod()
        {
            _tracer.StartTrace();
            //Thread.Sleep(100);
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("");
            }
            _tracer.StopTrace();
        }
        public void InnerMethod2()
        {
            int num = 5;
            for (int i = 0; i < 2000; i++)
            {
                num *= 5;
                Console.Write("");
            }
            _tracer.StartTrace();
            InnerMethod();
            //Thread.Sleep(150);
            _tracer.StopTrace();
        }
        public void InnerMethod3()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();
        }
    }
}