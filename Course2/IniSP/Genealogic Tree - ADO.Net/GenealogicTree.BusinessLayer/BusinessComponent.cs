using System.Collections.Generic;
using GenealogicTree.DAL;

namespace GenealogicTree.BusinessLayer
{
    public class BusinessComponent
    {
        private readonly string personTableName;
        private readonly string relativesTableName;

        private readonly ADO_DAL dal;

        public BusinessComponent()
        {
            dal = new ADO_DAL();
            personTableName = "dbo.Person";
            relativesTableName = "dbo.Relative";
        }
        #region Work with database
        public bool IsRegistated()
        {
            return dal.IsRegistrated(personTableName);
        }

        #region Add

        public string Add(Person person)
        {
            return dal.Add(ConvertTo.Dictionary(person), personTableName);
        }

        /// <summary>
        /// Возвращает сообщение, где будет результат добавления
        /// </summary>
        public string Add(Relative relative)
        {
            if (IsImmediateRelative(relative))
            {
                return dal.Add(ConvertTo.Dictionary(relative), relativesTableName);
            }
            return "Ошибка добавления";
        }
        #endregion

        /// <summary>
        /// Возвращает результат удаления
        /// </summary>
        public string Delete(Person person)
        {
            return dal.Delete(person.Id, personTableName, relativesTableName);
        }

        public void Update(Person newPerson)
        {
            dal.Update(ConvertTo.Dictionary(newPerson), personTableName);
        }

        public List<Person> GetAll()//возвращает все элементы
        {
            return ConvertTo.Person(dal.ReadAll(personTableName));
        }
        public List<Person> Search(Dictionary<string, string> searchStrings)
        {
            return ConvertTo.Person(dal.Search(searchStrings, personTableName));
        }

        public Person SearchById(int id)
        {
            return ConvertTo.Person(dal.SearchById(id, personTableName));
        }
        #endregion

        /// <summary>
        /// Возвращает словарь, в котором ключ--родственник, значение--кем он приходится
        /// </summary>
        public Dictionary<Person, KindOfRelative> GetMyRelatives()
        {
            return GetAllRelatives(ConvertTo.Person(dal.SearchMe(personTableName)));
        }

        private Dictionary<Person, KindOfRelative> GetAllRelatives(Person person)
        {
            var queue = new Queue<Person>();
            queue.Enqueue(person);
            //в этом списке будет храниться каждый родственник
            var visitedPoints = new List<Person> { person }; //добавляю себя туда
            Person point;
            Dictionary<Person, KindOfRelative> immediateRelatives;
            var allRelatives = new Dictionary<Person, KindOfRelative>();
            var relationsList = new List<KindOfRelative>();
            Person relative;
            while (queue.Count > 0)//здесь получаем с помощью обхода графа в ширину путь каждом родственнику
            {
                point = queue.Dequeue();
                immediateRelatives = ConvertTo.Dictionary(dal.GetImmediateRelatives(point.Id, personTableName, relativesTableName));
                foreach (var immediateRelative in immediateRelatives)
                {
                    relative = immediateRelative.Key;
                    queue.Enqueue(relative);
                    visitedPoints.Add(relative);
                    relationsList.Add(immediateRelative.Value);
                    if (allRelatives.ContainsKey(point))
                    {
                        relationsList.Add(allRelatives[point]);
                    }
                    allRelatives.Add(relative, RelationshipsDictionary.GetKindOfRelative(relationsList));
                    relationsList.Clear();
                }
            }
            return allRelatives;
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
