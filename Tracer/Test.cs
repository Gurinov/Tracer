using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Tracer
{
    [TestFixture]
    public class Test
    {
        private Tracer _tracer;
        
        public void Method()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
           
        }
        
        [Test]
        public void Tracer_Sleep200_ReturnedMore200()
        {
            _tracer = new Tracer();
            Method();
            Assert.True(int.Parse(_tracer.GetTraceResult().getMethodsTree().methods.Last().time) >= 200);
        }
        
        [Test]
        public void GetTraceResult_ReturnedMethod()
        {
            _tracer = new Tracer();
            Method();
            Assert.AreEqual(_tracer.GetTraceResult().getMethodsTree().methods.Last().methodName,"Method");
        }
        
        
        [Test]
        public void Node_ReturnedMethod()
        {
            _tracer = new Tracer();
            Method();
            Assert.AreEqual(_tracer.GetTraceResult().getMethodsTree().methods.Last().className, "Test");
        }
        
        [Test]
        public void setChilds_ReturnedTrue()
        {
            _tracer = new Tracer();
            Method();
            Assert.AreEqual(_tracer.GetTraceResult().getMethodsTree().methods.Last().getParent(), _tracer.GetTraceResult().getMethodsTree());
        }
        
        
        [Test]
        public void setTime_Returned123()
        {
            _tracer = new Tracer();
            Method();
            _tracer.GetTraceResult().getMethodsTree().setTime(_tracer.GetTraceResult().getMethodsTree(),
                    _tracer.GetTraceResult().getMethodsTree().methods.Last().className,_tracer.GetTraceResult().getMethodsTree().methods.Last().methodName,
                    _tracer.GetTraceResult().getMethodsTree().methods.Last().getParent().className, _tracer.GetTraceResult().getMethodsTree().methods.Last().getParent().methodName, "123");
            Assert.AreEqual(_tracer.GetTraceResult().getMethodsTree().methods.Last().time, "123");
        }
        
    }
}