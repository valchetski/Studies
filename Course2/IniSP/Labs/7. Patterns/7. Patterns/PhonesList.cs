using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Patterns
{
    [Serializable]
    public class PhonesList : List<Phone>
    {
        public void Insert(string name, double cost, string color)
        {
            string key = Singleton.GetInstance().GetKey(name);
            var newPhone = new Phone(name, cost, color, key);
            this.Add(newPhone);
        }
        public string GetAllPhones()
        {
            string allPhones;
            if (this.Count != 0)
            {
                allPhones = "\nВсе телефоны: ";
                foreach(Phone phone in this)
                {
                    allPhones += "\n" + phone.name;
                    allPhones += "\n\t" + phone.cost;
                    allPhones += "\n\t" + phone.color;
                }
            }
            else
            {
                allPhones = "\nСписок телефонов пуст";
            }
            return allPhones;
        }
    }
}
