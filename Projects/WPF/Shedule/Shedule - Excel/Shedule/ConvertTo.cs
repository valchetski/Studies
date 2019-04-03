using System;
using System.Collections.Generic;
using System.Linq;
using Shedule.ConstantContainers;

namespace Shedule
{
    public static class ConvertTo
    {
        public static Period Period(List<List<string>> list)
        {
            string day = (list[0])[0];

            string week = "";
            foreach (var numberOfWeek in list[1])
            {
                if (numberOfWeek != "")
                {
                    week += numberOfWeek + ",";
                }
            }
            int index = week.LastIndexOf(",", StringComparison.Ordinal);
            if (index > -1)
            {
                week = week.Remove(index, 1);
            }

            string time = (list[2])[0];
            string subgroup = (list[3])[0];
            string discipline = (list[4])[0];
            string auditorium = (list[5])[0];
            string teacher = (list[6])[0];
            string type = (list[7])[0];

            return new Period(day, week, time, subgroup, discipline, type, auditorium, teacher);
        }
        
        public static string DayOfWeek(DateTime? selectedDay)
        {
            DateTime day = selectedDay != null ? selectedDay.Value : DateTime.Now;
            switch (day.DayOfWeek)
            {
                case System.DayOfWeek.Monday:
                    return DOW.Monday;
                case System.DayOfWeek.Tuesday:
                    return DOW.Tuesday;
                case System.DayOfWeek.Wednesday:
                    return DOW.Wednesday;
                case System.DayOfWeek.Thursday:
                    return DOW.Thursday;
                case System.DayOfWeek.Friday:
                    return DOW.Friday;
                case System.DayOfWeek.Saturday:
                    return DOW.Saturday;
                case System.DayOfWeek.Sunday:
                    return DOW.Sunday;
                default:
                    return DOW.NotDayOfWeek;
            }
        }

        public static string Subgroup(int subgroup)
        {
            switch (subgroup)
            {
                case 1:
                    return ConstantContainers.Subgroup.First;
                case 2:
                    return ConstantContainers.Subgroup.Second;
                case 0:
                    return ConstantContainers.Subgroup.All;
                default:
                    return ConstantContainers.Subgroup.Default;
            }
        }
    }
}
