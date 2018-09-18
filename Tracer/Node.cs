using System.Collections.Generic;

namespace Tracer
{
    public class Node
    {
        public string className;
        public string methodName;
        public string time;
        private Node parent = null;

        public List<Node> methods = new List<Node>() {};

        public Node()
        {
            this.className = "";
            this.methodName = "";
        }
        
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
        public List<Node> getMethods()
        {
            return this.methods;
        }

        public void setChilds(Node node)
        {
            foreach (var child in node.methods)
            {
                child.parent = node;
            }
        }

        public void addNode(Node node, string parentClassName, string parentMethotName, string className, string methotName)
        { 
            if (node.getClassName().Equals(parentClassName) && node.getMethodName().Equals(parentMethotName))
            {
                node.methods.Add(new Node(className,methotName));
                setChilds(node);
            } 
            else
            {
                foreach (Node child in node.methods)
                {
                    addNode(child, parentClassName, parentMethotName, className, methotName);
                }
            }
        }

        public void setTime(Node node, string className, string methotName, string parentClassName, string parentMethotName, string time)
        {
            if (node.getClassName().Equals(className) && node.getMethodName().Equals(methotName) && 
                node.parent.getClassName().Equals(parentClassName) && node.parent.getMethodName().Equals(parentMethotName) &&
                node.parent != null)
            {
                node.time = time;
            } 
            else
            {
                foreach (Node child in node.methods)
                {
                    setTime(child, className, methotName, parentClassName, parentMethotName, time);
                }
            }
        }

    }
}