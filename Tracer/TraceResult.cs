using System;
using System.Collections.Concurrent;

namespace Tracer
{
    public class TraceResult
    {
        private Node methodsTree;
        private readonly ConcurrentDictionary<int, Node> allMethods = new ConcurrentDictionary<int, Node>();

        public ConcurrentDictionary<int, Node> getAllMethods()
        {
            return allMethods;
        }
        
        public TraceResult(Node tree)
        {
            methodsTree = tree;
        }

        public Node getMethodsTree()
        {
            return methodsTree;
        }
        
    }
}