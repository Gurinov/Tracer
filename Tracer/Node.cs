using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Tracer
{
    public class Node
    {
        public string className;
        public string methodName;
        public string time = "-1";
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
        
        public string getTime()
        {
            return this.time;
        }
        
        public Node getParent()
        {
            return this.parent;
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

        public bool addNode(Node node, string parentClassName, string parentMethotName, string className, string methotName)
        { 
            if (node.getClassName().Equals(parentClassName) && node.getMethodName().Equals(parentMethotName) && (node.methods.Count > 0 && !addNode(node.methods.Last(), parentClassName, parentMethotName, className, methotName))) 
            {
                node.methods.Add(new Node(className,methotName));
                setChilds(node);
                return true;
            } 
            else
            {
                foreach (Node child in node.methods)
                {
                    if(addNode(child, parentClassName, parentMethotName, className, methotName))
                        return false;
                }
            }
            return false;
        }
        
        public bool setTime(Node node, string className, string methotName, string parentClassName, string parentMethotName, string time)
        {
            if (node.getClassName().Equals(className) && node.getMethodName().Equals(methotName) && 
                node.parent.getClassName().Equals(parentClassName) && node.parent.getMethodName().Equals(parentMethotName) && (node.getTime().Equals("-1")))
            {
                node.time = time;
                return true;
            } 
            else
            {
                foreach (Node child in node.methods)
                {
                    if (setTime(child, className, methotName, parentClassName, parentMethotName, time))
                        return false;
                }
            }
            return false;
        }

    }
}