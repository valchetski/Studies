using System;
using System.Collections.Generic;

namespace GenealogicTree.BusinessLayer
{
    public class Person
    {
        #region FieldsForProperties
        private string firstName;
        private string patronymic;
        private string surName;
        
        private DateTime birthDayDateTime;
        private DateTime deadDayDateTime;
        private int age;

        private string biography;
        #endregion

        #region Fields
        public bool isAlive;
        private List<string> illegalSymbols;
        public DateTime liveDateTime;//дата смерти для живых пользователей
        #endregion

        #region Properties
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if ((value.Length > 1) && (!IsIllegalSymbolIn(value)))
                {
                    firstName = value;
                }
                else
                {
                    throw new IncorrectDataEntry("Имя не может содержать запрещенных символов " +
                                                 "и его длина должна быть больше 1-го символа." +
                                                 "\nПовторите ввод"); 
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
                                                 "и его длина должна быть больше 1-го символа." +
                                                 "\nПовторите ввод");
                }
            }
        }

        public DateTime BirthDayDateTime
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

        public DateTime DeadDayDateTime
        {
            get { return deadDayDateTime; }
            set
            {
                if ((value <= DateTime.Now) && (value >= BirthDayDateTime))
                {
                    deadDayDateTime = value;
                    deadDayDateTime = new DateTime(deadDayDateTime.Year, deadDayDateTime.Month, deadDayDateTime.Day,0,0,0,0);
                    isAlive = false;
                }
                else
                {
                    deadDayDateTime = liveDateTime;
                    isAlive = true;
                    if (value != liveDateTime)
                    {
                        throw new IncorrectDataEntry(
                            "Дата смерти не может быть позже сегодняшней даты или раньше дня рождения человека" +
                            "\nПовторите ввод");
                    }
                }
            }
        }

        public int Age
        {
            get
            {
                if ((DeadDayDateTime != default(DateTime)) && (BirthDayDateTime != default(DateTime)))
                {
                    var lastDayOfLive = (DeadDayDateTime == liveDateTime) ? DateTime.Now : DeadDayDateTime;
                    age = lastDayOfLive.Year - BirthDayDateTime.Year;

                    if ((BirthDayDateTime.Month >= lastDayOfLive.Month) && (BirthDayDateTime.Day > lastDayOfLive.Day))
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

        public int Id
        {
            get {return (FirstName + Patronymic + SurName).GetHashCode(); }
        }

        public string Biography
        {
            get { return biography; }
            set
            {
                if ((value != null) && (value.Length > 10))
                {
                    biography = value;
                }
                else
                {
                    biography = "Отсутствует";
                }
            }
        }
        #endregion

        public Person(string firstName, string patronymic, string surName, DateTime birthDayDateTime, DateTime deadDayDateTime, string biography)
        {
            Initialize(); 
            FirstName = firstName;
            Patronymic = patronymic;
            SurName = surName;
            BirthDayDateTime = birthDayDateTime;
            DeadDayDateTime = deadDayDateTime;
            Biography = biography;
        }
        public Person()
        {
            Initialize();
        }

        private void Initialize()
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
                foreach (var elementOfValue in checkingString)
                {
                    if (illegalSymbols.Contains(Convert.ToString(elementOfValue)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
