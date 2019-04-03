using System;
using System.Collections.Generic;

namespace Shedule.BusinessLayer
{
    public static class ConvertTo
    {
        public static Period Period(List<string> list)
        {
            if (list.Count == 8)
            {
                string week = list[0];
                string time = list[1];
                string discipline = list[2];
                string subgroup = list[3];
                string auditorium = list[4];
                string teacher = list[5];
                string type = list[6];
                string day = list[7];

                return new Period(day, week, time, subgroup, discipline, type, auditorium, teacher);
            }
            return default(Period);
        }

        public static Task Task(List<string> list)
        {
            if (list.Count == 3)
            {
                string subjectName = list[0];
                DateTime deadLineTime = Convert.ToDateTime(list[1]);
                string taskName = list[2];
                
                return new Task(subjectName, deadLineTime, taskName);
            }
            return null;
        }

        public static string Day(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Понедельник";
                case DayOfWeek.Tuesday:
                    return "Вторник";
                case DayOfWeek.Wednesday:
                    return "Среда";
                case DayOfWeek.Thursday:
                    return "Четверг";
                case DayOfWeek.Friday:
                    return "Пятница";
                case DayOfWeek.Saturday:
                    return "Суббота";
                case DayOfWeek.Sunday:
                    return "Воскресенье";
                default:
                    return "Понедельник";
            }
        }
    }
}