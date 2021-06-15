using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;

namespace T4Plus.Generator
{
    internal class Program
    {
        private static readonly Type WriterType = typeof(CodeWriter);
        private static readonly Type TypeType = typeof(Type);
        

        private static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Error.WriteLine("Usage: T4Plus path/to/project.dll /path/to/auto_generated_source.cs");
                return 1;
            }

            var dllFilepath = args[0];
            var outputFilePath = args[1];
            Console.WriteLine("dll file      is in "+dllFilepath);
            Console.WriteLine("out file will be in "+outputFilePath);
            try
            {
                using (var writer = new CodeWriter(outputFilePath))
                {
                    var assembly = Assembly.LoadFile(dllFilepath);
                    foreach (var type in assembly.GetTypes())
                    {
                        if (ProcessType(writer, type))
                        {
                            Console.WriteLine("processed type " + type.FullName);
                        }
                    }
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return 2;
            }

            return 0;
        }

        
        private static bool ProcessType(IndentedTextWriter writer, Type type)
        {
            var processed = false;
            var attributes = type.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                var method = attribute.GetType().GetMethods().FirstOrDefault(x =>
                    x.Name.Equals(nameof(GeneratorAttribute.Generate), StringComparison.InvariantCultureIgnoreCase));
                if (method != null)
                {
                    var methodParameters = method.GetParameters();
                    if (methodParameters.Length == 2)
                    {
                        var firstParam = methodParameters[0];
                        var secondParam = methodParameters[1];
                        if (firstParam.ParameterType == WriterType)
                        {
                            if (secondParam.ParameterType == TypeType)
                            {
                                try
                                {
                                    method.Invoke(attribute, new object[] { writer, type });
                                }
                                catch (Exception e)
                                {
                                    writer.WriteLine("//TODO error on generator "+attribute+" of type "+type.FullName);
                                    writer.WriteLine($"/*{e}*/");
                                }
                                processed = true;
                            }
                        }
                    }
                }
            }

            return processed;
        }
    }
}
