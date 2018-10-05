using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Tracer
{
    public class Node
    {
        public string _className;
        public string _methodName;
        public string _time;
        private Node _parent = null;
        private Stopwatch stopwatch = new Stopwatch();
        public List<Node> _methods = new List<Node>() {};

        public Node()
        {
            _className = "";
            _methodName = "";
        }
        
        public Node(string className, string methodName)
        {
            _className = className;
            _methodName = methodName;
            stopwatch.Start();
        }
        
        public Node getParent()
        {
            return _parent;
        } 
        
        public List<Node> getMethods()
        {
            return _methods;
        }

        
        public void setTime()
        {
            _time = stopwatch.ElapsedMilliseconds.ToString();
            stopwatch.Stop();
        }

    }
}