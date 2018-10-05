using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

namespace Tracer
{
    public class Tracer : ITracer
    {
        private TraceResult _traceResult = new TraceResult(tree);
        public static Node tree = null;
        private ConcurrentDictionary<int, Node> _threads = new ConcurrentDictionary<int, Node>();
        public ConcurrentDictionary<int,Node> _methodsDictionary = new ConcurrentDictionary<int, Node>();
        
        public void StartTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            
            var stacktrace = new StackTrace();
            var prevframe = stacktrace.GetFrame(1);
            var method = prevframe.GetMethod();
            string methotName = method.Name;
            string className = method.ReflectedType.Name;

            _methodsDictionary.TryAdd(_methodsDictionary.Count, new Node(className, methotName));
            if (!_threads.ContainsKey(threadId))
            {
                _threads.TryAdd(threadId, _methodsDictionary[0]);
            }
            if (tree == null)
            {
                tree = _methodsDictionary[0];
            }
        }

        public void StopTrace()
        {
            tree = _threads[Thread.CurrentThread.ManagedThreadId];
            if (_methodsDictionary.Count > 1)
            {
                _methodsDictionary[_methodsDictionary.Count - 2].getMethods().Add(_methodsDictionary[_methodsDictionary.Count - 1]);
                _methodsDictionary[_methodsDictionary.Count - 1].setTime();
                _traceResult.getAllMethods().TryAdd(GetTraceResult().getAllMethods().Count, _methodsDictionary[_methodsDictionary.Count - 1]);
                Node str1;
                _methodsDictionary.TryRemove(_methodsDictionary.Count - 1,out str1);   
            }
            else
            {
                _methodsDictionary[_methodsDictionary.Count - 1].setTime();
                _traceResult.getAllMethods().TryAdd(_traceResult.getAllMethods().Count,_methodsDictionary[_methodsDictionary.Count - 1]);
            }
        }

        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }
        
        
        public Node GetMethodThree(int index)
        {
            return _threads[index];
        }
       
        public int GetExecutionTime()
        {
            int time = 0;
            foreach (var thread in _threads)
            {
                time += Convert.ToInt32(_threads[thread.Key]._time);        
            }
            return time;
        }
    }
}