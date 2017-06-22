using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Student
    {
        public string Name { get; set; }
        public string GroupNumber { get; set; }
        public Dictionary<string, int> marks = new Dictionary<string, int>();
        public Student(string name, string num, Dictionary<string,int> t)
        {
            Name = name;
            GroupNumber = num;
            marks = t;
        }
    }
}
