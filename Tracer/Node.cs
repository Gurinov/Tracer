using System.Collections.Generic;

namespace Tracer
{
    public class Node
    {
        private string className;
        private string methodName;
        public Node parent = null;
        public List<Node> childs = new List<Node>() {};

        public Node(string className, string methodName)
        {
            this.className = className;
            this.methodName = methodName;
        }

        public string getClassName()
        {
            return this.className;
        }
        public string getMethodName()
        {
            return this.methodName;
        }

        public void setChilds(Node node)
        {
            foreach (var child in node.childs)
            {
                child.parent = node;
            }
        }

        public void addNode(Node node, string parentClassName, string parentMethotName, string className, string methotName)
        { 
            if (node.getClassName().Equals(parentClassName) && node.getMethodName().Equals(parentMethotName))
            {
                node.childs.Add(new Node(className,methotName));
                setChilds(node);
            } 
            else
            {
                foreach (Node child in node.childs)
                {
                    addNode(child, parentClassName, parentMethotName, className, methotName);
                }
            }
        }
    }
}