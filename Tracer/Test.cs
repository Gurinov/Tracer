using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tracer
{
    [TestFixture]
    public class Test
    {
        private Tracer _tracer;
        
        private void Method0()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }
        
        public void Method()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            Method2();
            Method3();
            _tracer.StopTrace();
        }
        
        public void Method2()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            Method3();
            _tracer.StopTrace();
        }

        public void Method3()
        {
            _tracer.StartTrace();
            Thread.Sleep(50);
            _tracer.StopTrace();
        }
       
        [Test]
        public void Tracer_Sleep200_ReturnedMore200()
        {
            _tracer = new Tracer();
            Method();
            Assert.True(_tracer.GetExecutionTime() >= 200);
        }
        
        [Test]
        public void GetTraceResult_ReturnedMethod()
        {
            _tracer = new Tracer();
            Method();
            Assert.AreEqual(_tracer.GetTraceResult().getAllMethods()[0]._methodName,"Method3");
        }
        
        
        [Test]
        public void Node_ReturnedMethod()
        {
            _tracer = new Tracer();
            Method();
            Assert.AreEqual(_tracer.GetTraceResult().getMethodsTree()._methods.Last()._className, "Test");
        }

        public int multiThreadedTracer()
        {
            Tracer tracer = new Tracer();
            Method();
            return int.Parse(tracer.GetTraceResult().getMethodsTree()._methods.Last()._time);
        }
        
        [Test]
        public void multiThreadedTest()
        {
            _tracer = new Tracer();
            long expected = 0;
            var threads = new List<Thread>();
            for (int i = 0; i < 2; i++)
            {    
                Thread thread = new Thread(Method);
                threads.Add(thread);
                thread.Start();
                expected += 200;
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            } 
            Assert.IsTrue(_tracer.GetExecutionTime() >= expected);
            
            /* _tracer = new Tracer();
            long expected = 0;
            Thread thread1 = new Thread(Method);
            Thread thread2 = new Thread(Method);
            thread1.Start();
            thread2.Start();
            expected += 200;
            thread1.Join();
            thread2.Join();
             
            Assert.IsTrue(_tracer.GetExecutionTime() >= expected);*/
        }
        
    }
}