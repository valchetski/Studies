using System;
using System.IO;
using System.Linq;

namespace Shedule
{
    public static class RunOptions
    {
        private const string fileOptionsName = @"files\runOptions.txt";
        private static int mySubgroup;
        public static int MySubgroup
        {
            get { return mySubgroup; }
            set
            {
                if((value != 1) && (value != 2))
                {
                    value = 1;
                }
                mySubgroup = value;
            }
        }
        static RunOptions()
        {
            try
            {
                using (var reader = new StreamReader(fileOptionsName))
                {
                    MySubgroup = Convert.ToInt32(reader.ReadLine());
                }
                return;
            }
            catch (FileNotFoundException)
            {
                var file = File.Create(fileOptionsName);
                file.Close();
            }
            catch(FormatException) {}
            catch(DirectoryNotFoundException)
            {
                string directoryPath = fileOptionsName.Split('\\').FirstOrDefault();
                if (directoryPath != null)
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            MySubgroup = 1;
        }
        public static void SaveOptions(int newMySubgroup)
        {
            MySubgroup = newMySubgroup;
            using (var writenToFile = new StreamWriter(fileOptionsName))
            {
                writenToFile.WriteLine(Convert.ToString(MySubgroup));
            }
        }
    }
}
