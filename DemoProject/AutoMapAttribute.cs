using System;
using System.Linq;
using DemoProject;
using T4Plus;

namespace DemoProject
{
    public class AutoMapAttribute: GeneratorAttribute
    {
        public Type OtherType { get; set; }

        public AutoMapAttribute(Type otherType)
        {
            OtherType = otherType;
        }

        public override void Generate(CodeWriter writer, Type type)
        {
            using (writer.Namespace(type.Namespace))
            {
                writer.Write("public static partial ");
                using (writer.Class("Extensions"))
                {
                    writer.WriteLine(
                        $"public static {type.FullName} Map(this {OtherType.FullName} {OtherType.Name.FirstToLower()})");
                    writer.WriteLine("{");
                    writer.Indent++;
                    var props = type.GetProperties();
                    var otherProps = OtherType.GetProperties();
                    writer.WriteLine($"if({OtherType.Name.FirstToLower()}==null) return null;");
                    writer.WriteLine($"var result = new {type.FullName}();");
                    foreach (var prop in props)
                    {
                        var otherProp = otherProps.FirstOrDefault(x => x.Name == prop.Name);
                        if (otherProp==null)
                        {
                            writer.WriteLine($"//TODO no prop match for {prop.Name} in other type");
                            continue;
                        }

                        if (!prop.CanWrite)
                        {
                            writer.WriteLine($"//TODO prop {prop.Name} has no set");
                            continue;
                        }
                        
                        if (!otherProp.CanRead)
                        {
                            writer.WriteLine($"//TODO prop {prop.Name} from other class has no get");
                            continue;
                        }
                        writer.WriteLine($"result.{prop.Name} = result.{prop.Name};");
                    }

                    writer.WriteLine("return result;");
                    writer.Indent--;
                    writer.WriteLine("}");
                }
            }
        }
    }
}