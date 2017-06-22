using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Collection
{
    class Collection_Product : List<Product>, IDisposable, IEnumerable<Product> 
    {
        public void Insert(string new_name, string brand_name, int new_cost)
        {
            int index = this.GetIndex(new_name);
            if (index == -1)//товар не найден
            {
                var new_product = new Product();
                new_product.name = new_name;
                base.Add(new_product);
                index = this.Count - 1;
            }
            this[index].Add(new Brand { name = brand_name, product_name = this[index].name, cost = new_cost });
            this[index] = this[index].Sort();
        }

        public string Print_all()
        {
            string result = "";
            bool products_found = false;
            foreach (Product product in this)
            {
                result += product.name + ":\n";
                foreach (Brand brand in product)
                {
                    result += "\t" + brand.name + " " + brand.cost + "руб\n";
                }
                products_found = true;
            }
            if (products_found)
                return ("Все товары:\n" + result);
            else
                return "Товаров в покупке нет!:(";
        }

        public string Delete(string delete_product)
        {
            bool isFound = Delete1(delete_product);
            string result = "Этого экземпляра товара нет в списке покупок!";
            while (isFound)
            {
                isFound = Delete1(delete_product);
                result = "Удаление прошло успешно";
            }
            return result;
        }

        private bool Delete1(string delete_product)
        {
            int j = 0;
            bool isFound = false;
            foreach (Product product in this)
            {
                foreach (Brand brand in product)
                {
                    if (brand.name == delete_product)
                    {
                        this[j].Remove(brand);
                        if (this[j].Count == 0)
                            this.Remove(product);
                        isFound = true;
                        return isFound;
                    }
                }
                j++;
            }
            return isFound;
        }

        public int GetIndex(string search_product)
        {
            int index = 0;
            bool found = false;
            foreach (Product product in this)
            {
                if (product.name == search_product)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (!found)
                return (-1);
            else
                return index;
        }

        public string Search(string search_product)
        {
            int index = 0;
            bool found = false;
            foreach (Product product in this)
            {
                if (product.name == search_product)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (!found)
                return ("Товар не найден!");
            else
            {
                string result = ("Результаты поиска:\n" + this[index].name + ":\n");
                foreach (Brand brand in this[index])
                {
                    result += ("\t" + brand.name + " " + brand.cost + "руб\n");
                }
                return result;
            }
        }

        public string Filter(int filtrusha)
        {
            string result = "";
            foreach (Product product in this)
            {
                string temp_result = product.Filter(filtrusha);
                if (temp_result != "")
                    result += product.name + ":\n\t" + temp_result;
            }
            if (result != "")
                return result;
            else
                return null;
        }

        public string Projection()
        {
            string result = "";
            var name_list = this.Select(Product => Product.name);
            foreach (string name in name_list)
            {
                result += "\t" + name + "\n";
            }
            return result;
        }

        public void Dispose()//реализую интерфейс IDisposable
        {
            this.Clear();
        }

        ~Collection_Product()//финализатор
        {
            this.Dispose();
        }

        public new IEnumerator<Product> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }
    }
}
