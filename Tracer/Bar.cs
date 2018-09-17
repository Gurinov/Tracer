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
            _tracer.StopTrace();
        }
        public void InnerMethod2()
        {
            _tracer.StartTrace();
            InnerMethod();
            _tracer.StopTrace();
        }
        public void InnerMethod3()
        {
            _tracer.StartTrace();
            InnerMethod();
            _tracer.StopTrace();
        }
    }
}