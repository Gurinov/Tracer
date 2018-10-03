using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tracer
{
    public class Tracer : ITracer
    {
        private TraceResult _traceResult;
        public static Node tree = null;
        public Dictionary<int,Node> _methodsDictionary = new Dictionary<int, Node>();
        
        public void StartTrace()
        {
            var stacktrace = new StackTrace();
            
            var prevframe = stacktrace.GetFrame(1);
            var method = prevframe.GetMethod();
            string methotName = method.Name;
            string className = method.ReflectedType.Name;

            _methodsDictionary.Add(_methodsDictionary.Count, new Node(className, methotName));
            
            if (tree == null)
            {
                tree = _methodsDictionary[0];
            }
        }

        public void StopTrace()
        {
            if (_methodsDictionary.Count > 1)
            {
                _methodsDictionary[_methodsDictionary.Count - 2].getMethods().Add(_methodsDictionary[_methodsDictionary.Count - 1]);
                _methodsDictionary[_methodsDictionary.Count - 1].setTime();
                _methodsDictionary.Remove(_methodsDictionary.Count - 1);   
            }
            else
            {
                _methodsDictionary[_methodsDictionary.Count - 1].setTime();
            }
        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(tree);
        }
    }
}