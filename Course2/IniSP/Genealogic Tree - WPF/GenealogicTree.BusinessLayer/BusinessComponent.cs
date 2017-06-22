using System.Collections.Generic;
using GenealogicTree.DAL;
using GenealogicTree.Entities;

namespace GenealogicTree.BusinessLayer
{
    public static class BusinessComponent
    {
        #region Work with database
        public static bool IsRegistated()
        {
            return EntityFrameworkDAL.IsRegistrated();
        }

        #region Add

        public static string Add(Person person)
        {
            return EntityFrameworkDAL.Add(person);
        }

        /// <summary>
        /// Возвращает сообщение, где будет результат добавления
        /// </summary>
        public static string Add(Relative relative)
        {
            if (IsImmediateRelative(relative))
            {
                return EntityFrameworkDAL.Add(relative);
            }
            return "Ошибка добавления";
        }
        #endregion

        /// <summary>
        /// Возвращает результат удаления
        /// </summary>
        public static string Delete(Person person)
        {
            return EntityFrameworkDAL.Delete(person);
        }

        public static void Update(Person newPerson)
        {
            EntityFrameworkDAL.Update(newPerson);
        }

        public static List<Person> GetAll()
        {
            return EntityFrameworkDAL.ReadAll();
        }

        public static List<Person> SearchByAllParametrsAdvanced(List<string> searchStrings)
        {
            return EntityFrameworkDAL.SearchByAllParametrs(searchStrings);
        }

        public static Me SearchMe()
        {
            return EntityFrameworkDAL.SearchMe();
        }

        #endregion

        public static Dictionary<Person, KindOfRelative> GetImmediateRelatives(int id)
        {
            return EntityFrameworkDAL.GetImmediateRelatives(id);
        }
        
        private static bool IsImmediateRelative(Relative relative)
        {
            switch (ConvertTo.KindOfRelative(relative.KindOfRelative))
            {
                case KindOfRelative.Father:
                case KindOfRelative.Mother:
                case KindOfRelative.Brother:
                case KindOfRelative.Sister:
                case KindOfRelative.Wife:
                case KindOfRelative.Husband:
                    return true;
                default:
                    return false;
            }
        }
    }
}
