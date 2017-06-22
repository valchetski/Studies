using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public interface IRepository//работа с файлом
    {
        void SaveToFile(Student st,string filename);
        Student LoadFromFile(string filename);

    }
}
