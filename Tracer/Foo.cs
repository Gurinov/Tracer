namespace Tracer
{
    public class Foo
    {
        private Bar _bar;
        private Tracer _tracer;
​
        internal Foo(Tracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }
    
        public void MyMethod()
        {
            _tracer.StartTrace();
            _bar.InnerMethod();
            MyMethod2();
            _tracer.StopTrace();
        }
        
        public void MyMethod2()
        {
            _tracer.StartTrace();
            _bar.InnerMethod2();
            _tracer.StopTrace();
        }
        
        public void MyMethod3()
        {
            _tracer.StartTrace();
            _bar.InnerMethod3();
            _tracer.StopTrace();
        }
    }
}