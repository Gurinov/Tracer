using System;
using System.Diagnostics;

namespace Tracer
{
    public class Tracer : ITracer
    {
        private TraceResult _traceResult;
        private Stopwatch _timer = new Stopwatch();
        private static Node tree = null;
        
        public static void Main(string[] args)
        {
            Tracer tracer = new Tracer();
            Foo foo = new Foo(tracer);
            foo.MyMethod();
        }

        public void StartTrace()
        {
            
            var stacktrace = new StackTrace();
            var prevframe = stacktrace.GetFrame(1);
            var method = prevframe.GetMethod();
            
            var prevframe1 = stacktrace.GetFrame(2);
            var method1 = prevframe1.GetMethod();
            string parentMethotName = method1.Name;
            string parentClassName = method1.ReflectedType.Name;
            
            
            string methotName = method.Name;
            string className = method.ReflectedType.Name;



            if (tree == null)
            {
                tree = new Node(parentClassName,parentMethotName);
                tree.childs.Add(new Node(className,methotName));
            }
            else
                tree.addNode(tree, parentClassName, parentMethotName, className, methotName);
            
            _timer.Start();
        }

        public void StopTrace()
        {
            _timer.Stop();
            Console.WriteLine (_timer.ElapsedMilliseconds.ToString());
        }

        public TraceResult GetTraceResult()
        {

            return null;
        }
    }
}