using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    [Serializable]
    public class Product : List<Brand>, IDisposable
    {
        public string name;

        public string Filter(int filtrusha)
        {
            var filteredList = this.Where(brand => brand.cost >= filtrusha);
            string result = "";
            foreach (Brand brand in filteredList)
            {
                result += "\t" + brand.name + " " + brand.cost + "руб\n";
            }
            return result;
        }

        public new Product Sort()
        {
            var sortedList = this.OrderBy(brand => brand.cost);
            var copySortedList = new Product();
            foreach (Brand brand in sortedList)
            {
                copySortedList.Add(brand);
                copySortedList.name = brand.productName;
            }
            return copySortedList;
        }

        public void Dispose()//реализую интерфейс IDisposable
        {
            Clear();
        }

        ~Product()//финализатор
        {
            Dispose();
        }
    }
}
