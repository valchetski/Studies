using System;
using System.Collections.Generic;
using System.Text;

using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;
using System.Reflection;

namespace DynaCode
{
    class Program
    {
        static string[] code = {
            @"using System;
            namespace DynaCore
            {
               public class DynaCore
               {
                   static public void Main(string str)
                   {
                    double a = 0;
                                for (int i = 0; i< 10; i++)
                     {
                                    if (i< 5)
                                        a += i / 2.0;
                                    else
a -= i* 1.5;
                                }
Console.WriteLine(a);
                       
                   }
               }
            }"};

        static void Main(string[] args)
        {
            try {
                Console.Title = "";
                //if (args.Length != 0)
                //{
                string a = "";
                foreach (var item in args)
                {
                    a += ' ' + item;
                }
                code[0] = a;
                //code = args;
                CompileAndRun(code);
                //}

                Console.ReadKey(); }
            catch { }
        }

        static void CompileAndRun(string[] code)
        {
            CompilerParameters CompilerParams = new CompilerParameters();
            string outputDirectory = Directory.GetCurrentDirectory();

            CompilerParams.GenerateInMemory = true;
            CompilerParams.TreatWarningsAsErrors = false;
            CompilerParams.GenerateExecutable = false;
            CompilerParams.CompilerOptions = "/optimize";

            string[] references = { "System.dll" };
            CompilerParams.ReferencedAssemblies.AddRange(references);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, code);

            if (compile.Errors.HasErrors)
            {
                string text = "Compile error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    text += "rn" + ce.ToString();
                }
                throw new Exception(text);
            }

            //ExpoloreAssembly(compile.CompiledAssembly);

            Module module = compile.CompiledAssembly.GetModules()[0];
            Type mt = null;
            MethodInfo methInfo = null;

            if (module != null)
            {
                mt = module.GetType("DynaCore.DynaCore");
            }

            if (mt != null)
            {
                methInfo = mt.GetMethod("Main");
            }

            if (methInfo != null)
            {
                Console.WriteLine(methInfo.Invoke(null, new object[] { "here in dyna code" }));
            }
        }

        static void ExpoloreAssembly(Assembly assembly)
        {
            Console.WriteLine("Modules in the assembly:");
            foreach (Module m in assembly.GetModules())
            {
                Console.WriteLine("{0}", m);

                foreach (Type t in m.GetTypes())
                {
                    Console.WriteLine("t{0}", t.Name);

                    foreach (MethodInfo mi in t.GetMethods())
                    {
                        Console.WriteLine("tt{0}", mi.Name);
                    }
                }
            }
        }
    }
}