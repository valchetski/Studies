using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCompiler
{
    public class CSharpCompilerMini
    {
        public static void Begin(string text)
        {
            try {
                System.Diagnostics.Process.Start(@"D:\Work\ConsoleApplication\ConsoleApplication\bin\Debug\ConsoleApplication.exe", text);
            }
            catch
            {

            }
        }
    }
}
