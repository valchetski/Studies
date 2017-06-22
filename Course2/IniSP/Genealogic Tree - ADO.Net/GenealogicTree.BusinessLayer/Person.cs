using System;
using System.Collections.Generic;
using System.Linq;

namespace GenealogicTree.BusinessLayer
{
    public class Person
    {
        #region Fields
        private List<string> illegalSymbols;
        private DateTime liveDateTime;//дата смерти для живых пользователей
        public bool isAlive;
        #endregion

        #region FieldsForProperties

        private string firstName;
        private string patronymic;
        private string surName;

        private DateTime birthDayDateTime;
        private DateTime deadDayDateTime;
        private int age;

        private string biography;
        #endregion

        #region Properties

        public int Id { get; set; }

        public string FirstName
        {
            get{ return firstName;}
            set
            {
                if ((value.Length > 1) && (!IsIllegalSymbolIn(value)))
                {
                    firstName = value;
                }
                else
                {
                    throw new IncorrectDataEntry("Имя не может содержать запрещенных символов " +
                                                 "и его длина должна быть больше 1-го символа."); 
                }
            }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                if (!IsIllegalSymbolIn(value))
                {
                    patronymic = value;
                }
                else
                {
                    throw new IncorrectDataEntry("Отчество не может содержать запрещенных символов "+
                                                 "\nПовторите ввод"); 
                }
            }
        }

        public string SurName
        {
            get { return surName; }
            set
            {
                if ((value.Length > 1) && (!IsIllegalSymbolIn(value)))
                {
                    surName = value;
                }
                else
                {
                    throw new IncorrectDataEntry("Фамилия не может содержать запрещенных символов " +
                                                 "и его длина должна быть больше 1-го символа."); 
                }
            }
        }

        public DateTime BirthDay
        {
            get { return birthDayDateTime; }
            set
            {
                if (value <= DateTime.Now)
                {
                    birthDayDateTime = value;
                    birthDayDateTime = new DateTime(birthDayDateTime.Year, birthDayDateTime.Month, birthDayDateTime.Day, 0, 0, 0, 0);
                }
                else
                {
                    throw new IncorrectDataEntry("Дата рождения не может быть позже сегодняшней даты" +
                                                 "\nПовторите ввод");
                }
            }
        }

        public DateTime DeadDay
        {
            get { return deadDayDateTime; }
            set
            {
                if ((value <= DateTime.Now) && (value >= BirthDay) && (value != new DateTime()))
                {
                    deadDayDateTime = value;
                    deadDayDateTime = new DateTime(deadDayDateTime.Year, deadDayDateTime.Month, deadDayDateTime.Day,0,0,0,0);
                    isAlive = false;
                }
                else
                {
                    deadDayDateTime = liveDateTime;
                    isAlive = true;
                    if ((value != liveDateTime) && (value != new DateTime()))
                    {
                        throw new IncorrectDataEntry(
                            "Дата смерти не может быть позже сегодняшней даты или раньше дня рождения человека" +
                            "\nПовторите ввод");
                    }
                }
            }
        }

        public string Biography
        {
            get
            {
                if (String.IsNullOrEmpty(biography))
                {
                    biography = "Отсутствует";
                }
                return biography;
            }
            set
            {
                biography = ((value != null) && (value.Length > 10)) ? value : "Отсутствует";
            }
        }

        public bool IsItMe { get; set; }

        public int Age
        {
            get
            {
                if ((DeadDay != default(DateTime)) && (BirthDay != default(DateTime)))
                {
                    var lastDayOfLive = (DeadDay == liveDateTime) ? DateTime.Now : DeadDay;
                    age = lastDayOfLive.Year - BirthDay.Year;

                    if ((BirthDay.Month >= lastDayOfLive.Month) && (BirthDay.Day > lastDayOfLive.Day))
                    {
                        age--;
                    }
                }
                else
                {
                    age = 0;
                }
                return age;
            }
        }
        #endregion

        public Person(int id, string firstName, string patronymic, string surName, DateTime birthDayDateTime,
            DateTime deadDayDateTime, string biography, bool isItMe)
        {
            Initialise();
            Id = id;
            FirstName = firstName;
            Patronymic = patronymic;
            SurName = surName;
            BirthDay = birthDayDateTime;
            DeadDay = deadDayDateTime;
            Biography = biography;
            IsItMe = isItMe;
        }

        public Person()
        {
            Initialise();
        }

        private void Initialise()
        {
            liveDateTime = DateTime.MaxValue;
            liveDateTime = new DateTime(liveDateTime.Year, liveDateTime.Month, liveDateTime.Day, 0, 0, 0, 0);
            illegalSymbols = new List<string> { " ", "!", "\"", "#", ";", "^", ":", "*", "(", ")", "+", "=", "\\", "|", "/" };
            for (int i = 1; i <= 9; i++)
            {
                illegalSymbols.Add(Convert.ToString(i));
            }
        }

        /// <summary>
        /// Проверка строки на наличие запрещенных символов
        /// </summary>
        /// <param name="checkingString"> Проверяемая строка </param>
        /// <returns></returns>
        private bool IsIllegalSymbolIn(string checkingString)
        {
            if (checkingString != null)
            {
                return checkingString.Any(value => illegalSymbols.Contains(Convert.ToString(value)));
            }
            return false;
        }
    }
}
