using System;

namespace GenealogicTree.Entities
{
    public class Person
    {
        #region FieldsForProperties
        private DateTime? birthDay;
        private DateTime? deadDay;
        #endregion

        #region Properties

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string SurName { get; set; }

        public DateTime? BirthDay
        {
            get { return birthDay; }
            set 
            {
                if (value != null)
                {
                    birthDay = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, 0, 0, 0, 0);
                }
                else
                {
                    birthDay = null;
                }
            }
        }

        public DateTime? DeadDay
        {
            get { return deadDay; }
            set
            {
                if (value != null)
                {
                    deadDay = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, 0, 0, 0, 0);
                }
                else
                {
                    deadDay = null;
                }
            }
        }

        public string Biography { get; set; }

        public string Photo { get; set; }

        public int? Age
        {
            get
            {
                var lastDayOfLive = DeadDay ?? DateTime.Now; //если DeadDay==null возвратит DateTime.Now
                 
                int? age;
                if (BirthDay == null)
                {
                    age = null;
                }
                else
                {
                    age = lastDayOfLive.Year - BirthDay.Value.Year;
                    if ((BirthDay.Value.Month >= lastDayOfLive.Month) && (BirthDay.Value.Day > lastDayOfLive.Day))
                    {
                        age--;
                    }
                }
                return age;
            }
        }
        #endregion
    }
}
