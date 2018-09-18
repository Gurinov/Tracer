using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Tracer.serialization;

namespace Tracer
{
    public class Tracer : ITracer
    {
        private TraceResult _traceResult;
        private Stopwatch _timer = new Stopwatch();
        public static Node tree = null;
        
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
                tree.getMethods().Add(new Node(className,methotName));
                tree.setChilds(tree);
            }
            else
                tree.addNode(tree, parentClassName, parentMethotName, className, methotName);
            
            _timer.Start();
        }

        public void StopTrace()
        {
            _timer.Stop();
            
            var stacktrace = new StackTrace();
            
            var prevframe = stacktrace.GetFrame(1);
            var method = prevframe.GetMethod();
            var prevframe1 = stacktrace.GetFrame(2);
            var method1 = prevframe1.GetMethod();
            string parentMethotName = method1.Name;
            string parentClassName = method1.ReflectedType.Name;
            string methotName = method.Name;
            string className = method.ReflectedType.Name;
            
            string time = _timer.ElapsedMilliseconds.ToString();
            tree.setTime(tree, className, methotName, parentClassName, parentMethotName, time);

            //Console.WriteLine (_timer.ElapsedMilliseconds.ToString());
        }

        public TraceResult GetTraceResult()
        {

            return null;
        }
    }
}