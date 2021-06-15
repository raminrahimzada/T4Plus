using System;

namespace T4Plus
{
    public class NamespaceDisposer : IDisposable
    {
        private readonly CodeWriter _codeWriter;

        public NamespaceDisposer(CodeWriter codeWriter,string namespaceName)
        {
            _codeWriter = codeWriter;
            _codeWriter.WriteLine($"namespace {namespaceName}");
            _codeWriter.WriteLine("{");
            _codeWriter.Indent++;
        }
        public void Dispose()
        {
            _codeWriter.Indent--;
            _codeWriter.WriteLine("}");
        }
    }
}