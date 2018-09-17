using System;

namespace Tracer
{
    public abstract class TraceResult
    {
        private string methodsName;
        private string className;
        private string time;

        public string getMethodsName()
        {
            return this.methodsName;
        }
        public string getClassName()
        {
            return this.className;
        }
        public string getTime()
        {
            return this.time;
        }

        public void setMethodsName(string methodsName)
        {
            this.methodsName = methodsName;
        }
        public void setClassName(string className)
        {
            this.className = className;
        }
        public void setTime(string time)
        {
            this.time = time;
        }
    }
}