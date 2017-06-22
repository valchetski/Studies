using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
   public interface IStatistics
    {
        double GPA(Student st);
        List<KeyValuePair<string, int>> Highest_score(Student st);
        List<KeyValuePair<string, int>> Lowest_score(Student st);
    }
}
