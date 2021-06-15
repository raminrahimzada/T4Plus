using System;

namespace T4Plus
{
    public class ClassDisposer : IDisposable
    {
        private readonly CodeWriter _codeWriter;

        public ClassDisposer(CodeWriter codeWriter, string className)
        {
            _codeWriter = codeWriter;
            codeWriter.WriteLine($"class {className}");
            codeWriter.WriteLine("{");
            _codeWriter.Indent++;
        }

        public void Dispose()
        {
            _codeWriter.Indent--;
            _codeWriter.WriteLine("}");
        }
    }
}