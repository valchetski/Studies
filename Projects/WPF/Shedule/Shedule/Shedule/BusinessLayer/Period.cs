using System;

namespace Shedule.BusinessLayer
{
    [Serializable]
    public class Period
    {
        //АЛЯРМ!!!!
        //порядок объявления свойств имеет значение при сохранении в файл
        //Аккуратно с этим

        #region Properties
        //если пусто -- значит предмет есть на каждой неделе
        public string Week { get; set; }
        public string Time { get; set; }
        public string Discipline { get; set; }
        public string Subgroup { get; set; }
        public string Auditorium { get; set; }
        public string Teacher { get; set; }
        public string Type { get; set; }
        public string Day { get; set; }
        #endregion

        public Period(string day, string week, string time, string subgroup, string discipline, string type, string auditorium, string teacher)
        {
            Day = day;
            Week = week;
            Time = time;
            Subgroup = subgroup;
            Discipline = discipline;
            Type = type;
            Auditorium = auditorium ?? "";
            Teacher = teacher ?? "";
        }

        public Period(){}
    }
}