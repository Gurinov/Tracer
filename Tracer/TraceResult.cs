using System;

namespace Tracer
{
    public class TraceResult
    {
        private Node methodsTree;

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