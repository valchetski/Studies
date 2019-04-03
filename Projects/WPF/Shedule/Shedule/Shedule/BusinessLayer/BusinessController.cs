using System;
using System.Collections.Generic;
using System.Linq;
using Shedule.DAL;

namespace Shedule.BusinessLayer
{
    public class BusinessController
    {
        public void SaveOptions(string subgroup)
        {
            Properties.Settings.Default.SubGroup = subgroup;
            Properties.Settings.Default.Save();
        }

        public List<Period> GetShedule(string adress)
        {
            return HTML.GetShedule(adress).Select(ConvertTo.Period).ToList();
        }

        public void Save(List<Period> shedule)
        {
            XML.Save(shedule);
        }

        public void Save(List<Task> tasks)
        {
            XML.Save(tasks);
        }

        public int GetWeek(DateTime selectedDate)
        {
            int numberOfWeek = 1;
            const int daysInOneWeek = 7;

            //сентябрь не всегда будет понедельником. А номер недели нужно считать с понедельника
            //поэтому находим дату, когда будет понедельник
            var firstSeptember = new DateTime(DateTime.Now.Year - (DateTime.Now.Month < 7 ? 1 : 0), 9, 1);
            int daysAfterMonday = DayOfWeek.Monday - firstSeptember.DayOfWeek;
            var firstDayOfStudyWeek = firstSeptember.AddDays(daysAfterMonday);

            for (var date = firstDayOfStudyWeek; date.AddDays(daysInOneWeek) <= selectedDate; date = date.AddDays(daysInOneWeek))
            {
                numberOfWeek++;
                if (numberOfWeek > 4)
                {
                    numberOfWeek = 1;
                }
            }
            return numberOfWeek;
        }

        public List<Period> GetSheduleForSelectedDay(DateTime selectedDate, string mySubgroup)
        {
            List<List<string>> elements = XML.GetShedule(selectedDate.DayOfWeek, GetWeek(selectedDate), mySubgroup);
            return elements != null ? elements.Select(ConvertTo.Period).ToList() : null;

        }

        /// <summary>
        /// Проверяет, будут или есть сегодня занятия
        /// Если их сегодня не было или не будет позже текущего времени
        /// то будет выводится расписание на следующий день
        /// </summary>
        public bool IsTherePeriods(List<Period> sheduleToday, DateTime selectedDate)
        {
            if (sheduleToday != null)
            {
                Period lastPeriod = sheduleToday.LastOrDefault();
                if (lastPeriod != null)
                {
                    string endLastPeriod = lastPeriod.Time;
                    int index = endLastPeriod.IndexOf('-');
                    string[] list = endLastPeriod.Substring(index + 1, endLastPeriod.Length - index - 1).Split(':');

                    DateTime endStudyTime;
                    try
                    {
                        endStudyTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day,
                            Convert.ToInt32(list[0]), Convert.ToInt32(list[1]), 0);
                    }
                    catch (FormatException)
                    {
                        endStudyTime = new DateTime();
                    }

                    return (endStudyTime >= DateTime.Now);
                }
                return false;
            }
            return false;
        }

        public List<Task> GetTasks()
        {
            return XML.GetTasks().Select(ConvertTo.Task).ToList();
        }
    }
}