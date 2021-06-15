using System;

namespace T4Plus
{
    public abstract class GeneratorAttribute : Attribute
    {
        public abstract void Generate(CodeWriter writer, Type type);
    }
}