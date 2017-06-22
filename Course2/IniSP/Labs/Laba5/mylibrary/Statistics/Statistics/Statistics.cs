using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;


namespace Statistics

{
    [NewAttribute("Statictics")]
    public class Statistics : IStatistics
    {
        public List<KeyValuePair<string, int>> Highest_score(Student st)
        {
            List<KeyValuePair<string, int>> z = new List<KeyValuePair<string, int>>();
            foreach (var t in st.marks)
                if (t.Value == st.marks.Values.Max())
                    z.Add(t);
            return z;
        }
        public List<KeyValuePair<string, int>> Lowest_score(Student st)
        {
            List<KeyValuePair<string, int>> z = new List<KeyValuePair<string, int>>();
            foreach (var t in st.marks)
                if (t.Value == st.marks.Values.Min())
                    z.Add(t);
            return z;
        }

        public double GPA(Student st)
        {
            return st.marks.Values.Average();//средняя оценка
        }
    }
}
