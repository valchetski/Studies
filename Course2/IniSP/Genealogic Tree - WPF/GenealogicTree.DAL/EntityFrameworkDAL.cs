using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenealogicTree.Entities;

namespace GenealogicTree.DAL
{
    public static class EntityFrameworkDAL
    {
        #region Add
        public static string Add(Person person)
        {
            using (var db = new PersonContext())
            {
                if ((person != null) && (GetPerson(person.Id) == null))
                {
                    db.Persons.Add(person);
                    db.SaveChanges();
                    return "Добавление выполнено успешно";
                }
                return "Такой человек уже существует";
            }
        }

        /// <summary>
        /// Возвращает сообщение, где будет результат добавления
        /// </summary>
        public static string Add(Relative relative)
        {
            string resultOfAdd = "";
            if (relative != null)
            {
                using (var db = new PersonContext())
                {
                    var allPersonId = db.Persons.Select(p => p.Id);
                    var immediateRelatives = GetImmediateRelatives(relative.PersonId);
                    if (immediateRelatives.ContainsValue(KindOfRelative.Father) &&
                        (ConvertTo.KindOfRelative(relative.KindOfRelative) == KindOfRelative.Father))
                    {
                        resultOfAdd = "Для этого человека уже был добавлен отец";
                    }
                    else if (immediateRelatives.ContainsValue(KindOfRelative.Mother) &&
                    (ConvertTo.KindOfRelative(relative.KindOfRelative) == KindOfRelative.Mother))
                    {
                        resultOfAdd = "Для этого человека уже была добавлена мама";
                    }
                    else if (db.Relatives.Count(r => (r.PersonId == relative.PersonId) && (r.RelativeOfPersonId == relative.RelativeOfPersonId)) != 0)
                    {
                        resultOfAdd = "Родственная связь между этими людьми уже существует";
                    }
                    else if (allPersonId.Contains(relative.PersonId) && allPersonId.Contains(relative.RelativeOfPersonId) &&
                        (relative.PersonId != relative.RelativeOfPersonId))
                    {
                        db.Relatives.Add(relative);
                        db.SaveChanges();
                        resultOfAdd = null;
                    }
                    else if (relative.PersonId == relative.RelativeOfPersonId)
                    {
                        resultOfAdd = "ID человека и его родственника не могут быть одинаковыми";
                    }
                    else
                    {
                        if (!allPersonId.Contains(relative.PersonId))
                        {
                            resultOfAdd = String.Format("Человека с id {0} не существует", relative.PersonId);
                        }
                        if (!allPersonId.Contains(relative.RelativeOfPersonId))
                        {
                            resultOfAdd += String.Format("\nЧеловека с id {0} не существует", relative.RelativeOfPersonId);
                        }
                    }
                }
            }
            else
            {
                resultOfAdd = "Ошибка добавления";
            }
            return resultOfAdd;
        }

        #endregion

        public static string Delete(Person person)
        {
            using (var db = new PersonContext())
            {
                if (CanRemovePerson(person))
                {
                    //удаляем человека
                    var entry = db.Entry(person);
                    if (entry.State == EntityState.Detached)
                    {
                        db.Persons.Attach(person);
                        db.Persons.Remove(person);
                    }

                    //удаляем все связи с ним
                    var relations =
                        db.Relatives.Where(r => (r.PersonId == person.Id) || (r.RelativeOfPersonId == person.Id));
                    foreach (var relation in relations)
                    {
                        db.Relatives.Remove(relation);
                    }
                    db.SaveChanges();
                    return null;
                }
                return "Чтобы удалить этого человека, удалите все связи с ним";
            }
        }

        /// <summary>
        /// Проверяет, есть ли у человека родственные связи
        /// Если есть связь только с одним человеком, то его можно удалять
        /// </summary>
        private static bool CanRemovePerson(Person person)
        {
            using (var db = new PersonContext())
            {
                return db.Relatives.Count(r => r.PersonId == person.Id) == 0;
            }
        }

        public static Me SearchMe()
        {
            using (var db = new PersonContext())
            {
                return db.Me.FirstOrDefault();
            }
        }

        public static List<Person> SearchByAllParametrs(List<string> searchStrings)
        {
            List<Person> foundPersons;
            using (var db = new PersonContext())
            {
                foundPersons = db.Persons.ToList();
            }

            return searchStrings.Aggregate(foundPersons,
                (current, searchString) =>
                    current.Where(
                        p =>
                            ((p.FirstName != null && p.FirstName.IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) != -1) ||
                             (p.Patronymic != null && p.Patronymic.IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) != -1) ||
                             (p.SurName != null && p.SurName.IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) != -1) ||
                             (p.BirthDay != null && String.Format("{0:dd.MM.yyyy}", p.BirthDay).IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) != -1) ||
                             (p.DeadDay != null && String.Format("{0:dd.MM.yyyy}", p.DeadDay).IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) != -1) ||
                             (Convert.ToString(p.Age).IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) != -1) ||
                             (p.Biography != null && p.Biography.IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) != -1)
                             )).ToList());
        }

        /// <summary>
        /// Возвращает только близких родственников человека: Папа, мама, сестра, брат
        /// </summary>
        public static Dictionary<Person, KindOfRelative> GetImmediateRelatives(int id)
        {
            var relatives = new Dictionary<Person, KindOfRelative>();
            using (var db = new PersonContext())
            {
                var personRelatives = db.Relatives.Where(r => r.PersonId == id);
                foreach (var relative in personRelatives)
                {
                    var myRelative = db.Persons.FirstOrDefault(p => p.Id == relative.RelativeOfPersonId);
                    if (myRelative != null)
                    {
                        relatives.Add(myRelative, ConvertTo.KindOfRelative(relative.KindOfRelative));
                    }
                }
            }
            return relatives;
        }

        public static List<Person> ReadAll()
        {
            using (var db = new PersonContext())
            {
                return db.Persons.ToList();
            }
        }

        public static void Update(Person newPerson)
        {
            using (var db = new PersonContext())
            {
                var person = db.Persons.FirstOrDefault(p => p.Id == newPerson.Id);
                if (person != null)
                {
                    person.FirstName = newPerson.FirstName;
                    person.Patronymic = newPerson.Patronymic;
                    person.SurName = newPerson.SurName;
                    person.BirthDay = newPerson.BirthDay;
                    person.DeadDay = newPerson.DeadDay;
                    person.Biography = newPerson.Biography;
                    person.Photo = newPerson.Photo;
                }
                db.SaveChanges();
            }
        }

        public static bool IsRegistrated()
        {
            using (var db = new PersonContext())
            {
                return (db.Me.Any()); //если список пуст--true
            }
        }

        private static Person GetPerson(int id)
        {
            using (var db = new PersonContext())
            {
                return (db.Persons.FirstOrDefault(p => p.Id == id));
            }
        }
    }
}
