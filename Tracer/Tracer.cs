using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tracer
{
    public class Tracer : ITracer
    {
        private TraceResult _traceResult;
        private List<Stopwatch> _timers = new List<Stopwatch>();
        private int i = 0;
        public static Node tree = null;
        
        public void StartTrace()
        {
            var stacktrace = new StackTrace();
            
            _timers.Add(new Stopwatch());
            _timers.Last().Start();
            
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
                tree.getMethods().Add(new Node(className,methotName));
                tree.setChilds(tree);
            }
            else
                tree.addNode(tree, parentClassName, parentMethotName, className, methotName);
            
        }

        public void StopTrace()
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
            
            string time = _timers.Last().ElapsedMilliseconds.ToString();
            _timers.Last().Stop();
            _timers.Remove(_timers.Last());
            tree.setTime(tree, className, methotName, parentClassName, parentMethotName, time);
        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(tree);
        }
    }
}