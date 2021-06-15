using System;

namespace T4Plus
{
    public class ScopeDisposer : IDisposable
    {
        private readonly CodeWriter _codeWriter;

        public ScopeDisposer(CodeWriter codeWriter)
        {
            _codeWriter = codeWriter;
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