using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Collection
{
    class Product : List<Brand>, IDisposable
    {
        public string name;

        public string Filter(int filtrusha)
        {
            var filtered_list = this.Where(Brand => Brand.cost >= filtrusha);
            string result = "";
            foreach (Brand brand in filtered_list)
            {
                result += "\t" + brand.name + " " + brand.cost + "руб\n";
            }
            return result;
        }

        public new Product Sort()                        
        {
            var sorted_list = this.OrderBy(Brand => Brand.cost);
            var copy_sorted_list = new Product();
            foreach (Brand brand in sorted_list)
            {
                copy_sorted_list.Add(brand);
                copy_sorted_list.name = brand.product_name;
            }
            return copy_sorted_list;
        }

        public void Dispose()//реализую интерфейс IDisposable
        {
            this.Clear();
        }

        ~Product()//финализатор
        {
            this.Dispose();
        }
    }
}
