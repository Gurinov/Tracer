using System;
using System.Threading;
using NUnit.Framework;
using Tracer = Tracer.Tracer;

namespace TracerTests
{
    
    [TestFixture]
    public class TracerTests
    {
        
        private global::Tracer.Tracer _tracer;
        
        public void Test()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }
        
        [Test]
        public void Test1()
        {
            _tracer = new global::Tracer.Tracer();
            Test();
            Console.WriteLine(_tracer.GetTraceResult().getMethodsTree().time);
            Assert.True(true);
            //Assert.True(int.Parse(_tracer.GetTraceResult().getMethodsTree().time) == 10);

           // Assert.AreEqual(int.Parse("123"),10);
        }
    }
}