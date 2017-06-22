using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.IO;

namespace Repository
{
    [NewAttribute("Repository")]
    public class Repository:IRepository//работа с файлом
    {
        public void SaveToFile(Student st, string filename)
        {
            File.Delete(filename);
            using (var stream = File.OpenWrite(filename))
            {
                using (var writer = new StreamWriter(stream, Encoding.GetEncoding("windows-1251")))
                {
                    writer.WriteLine("Фамилия:");
                    writer.WriteLine(st.Name);
                    writer.WriteLine("Номер группы:");
                    writer.WriteLine(st.GroupNumber);
                    writer.WriteLine("Оценки за сессию:");
                    foreach (var t in st.marks)
                    {
                        writer.WriteLine(t.Key + "-" + t.Value);
                    }
                }

            }
        }

        public Student LoadFromFile(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                using (var reader = new StreamReader(stream, Encoding.GetEncoding("windows-1251")))
                {
                    Dictionary<string, int> k = new Dictionary<string, int>();//хранится название предмета и оценка
                    reader.ReadLine();
                    string name = reader.ReadLine();
                    reader.ReadLine();
                    string num = reader.ReadLine();
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    { 
                    string[] y=reader.ReadLine().Split(new []{'-'});
                    k.Add(y[0],int.Parse(y[1]));
                    }
                    return new Student(name, num, k);
                }

            }
        }
    }
}
