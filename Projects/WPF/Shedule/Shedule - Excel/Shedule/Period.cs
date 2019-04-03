using System;
using System.Collections.Generic;
using System.Linq;
using Shedule.ConstantContainers;

namespace Shedule
{
    [Serializable]
    public class Period
    {
        #region Fields for properties
        private string day;
        private List<int> week;
        private string subgroup;
        private string type;
        #endregion

        #region Properties

        public string Day
        {
            get { return day; }
            set
            {
                switch (value)
                {
                    case "пн":
                        day = DOW.Monday;
                        break;
                    case "вт":
                        day = DOW.Tuesday;
                        break;
                    case "ср":
                        day = DOW.Wednesday;
                        break;
                    case "чт":
                        day = DOW.Thursday;
                        break;
                    case "пт":
                        day = DOW.Friday;
                        break;
                    case "сб":
                        day = DOW.Saturday;
                        break;
                    default:
                        day = DOW.NotDayOfWeek;
                        break;
                }
            }
        }

        public List<int> Week
        {
            get { return week; }
            set
            {
                //если пусто -- значит предмет есть на каждой неделе
                //week = value.Count != 0 ? value : new List<int> { 1, 2, 3, 4 };
                week = value;
            }
        }

        public string Time { get; set; }

        public string Subgroup
        {
            get { return subgroup; }
            set
            {
                switch (value)
                {
                    case "":
                        subgroup = ConstantContainers.Subgroup.All;
                        break;
                    case "1":
                        subgroup = ConstantContainers.Subgroup.First;
                        break;
                    case "2":
                        subgroup = ConstantContainers.Subgroup.Second;
                        break;
                    default:
                        subgroup = ConstantContainers.Subgroup.Default;
                        break;
                }
            }
        }

        public string Discipline { get; set; }

        public string Auditorium { get; set; }

        public string Teacher { get; set; }

        #endregion

        public string Type 
        {
            get { return type; }
            set
            {
                switch (value)
                {
                    case "лк":
                        type = TypePeriod.Lection;
                        break;
                    case "пз":
                        type = TypePeriod.Practice;
                        break;
                    case "лр":
                        type = TypePeriod.Laboratory;
                        break;
                    default:
                        type = TypePeriod.None;
                        break;
                }
            }
        }

        public Period(string day, string week, string time, string subgroup, string discipline, string type, string auditorium, string teacher)
        {
            Day = day;

            int i;
            Week = (from s in week.Split(',') where int.TryParse(s, out i) select Convert.ToInt32(s)).ToList();

            Time = time;
            Subgroup = subgroup;
            Discipline = discipline;
            Type = type;
            Auditorium = auditorium;
            Teacher = teacher;
        }

        public Period(){}
    }
}
