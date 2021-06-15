using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;

namespace T4Plus
{
    public class CodeWriter : IndentedTextWriter
    {
        public CodeWriter(string fileLocation) : base(new StreamWriter(fileLocation))
        {
        }

        protected CodeWriter(TextWriter writer) : base(writer)
        {
        }

        protected CodeWriter(TextWriter writer, string tabString) : base(writer, tabString)
        {
        }

        public void WriteLine(params string[] array)
        {
            foreach (var s in array)
            {
                base.WriteLine(s);
            }
        }
        public void WriteLine(IEnumerable<string> enumerable)
        {
            foreach (var s in enumerable)
            {
                base.WriteLine(s);
            }
        }
        public void Write(params string[] array)
        {
            foreach (var s in array)
            {
                base.Write(s);
            }
        }
        public void Write(IEnumerable<string> enumerable)
        {
            foreach (var s in enumerable)
            {
                base.Write(s);
            }
        }

        public void Using(params string[] nameSpaces)
        {
            foreach (var nameSpace in nameSpaces)
            {
                WriteLine($"using {nameSpace};");
            }
        }

        public void Comment(string comment)
        {
            WriteLine($"//{comment}");
        }
        public IDisposable Namespace(string namespaceName)
        {
            return new NamespaceDisposer(this, namespaceName);
        }
        public IDisposable Class(string className)
        {
            return new ClassDisposer(this, className);
        }
        public IDisposable BeginScope()
        {
            return new ScopeDisposer(this);
        }
    }
}
