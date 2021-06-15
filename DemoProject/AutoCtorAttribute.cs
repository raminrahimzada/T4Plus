using System;
using System.Linq;
using System.Reflection;
using T4Plus;

namespace DemoProject
{
    public class AutoCtorAttribute: GeneratorAttribute
    {
        public override void Generate(CodeWriter writer, Type type)
        {
            writer.Using("System");

            using (writer.Namespace(type.Namespace))
            {
                writer.Write("partial ");
                using (writer.Class(type.Name))
                {
                    var props = ((TypeInfo)type).DeclaredProperties.ToArray();

                    //ctor parameters
                    writer.Write($"public {type.Name}(");
                    writer.Write(props.Select(x => $"{x.PropertyType.FullName} {x.Name.FirstToLower()}").JoinWith(","));
                    writer.WriteLine(")");

                    using (writer.BeginScope())
                    {
                        //property setting section--multiple lines
                        writer.WriteLine(props.Select(x => $"this.{x.Name}={x.Name.FirstToLower()};"));
                    }
                }
                writer.Comment("TODO");
            }
        }
    }
}