using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.Security.Cryptography;

namespace _2.Collection
{
    class Collection_Product : List<Product>, IDisposable, IEnumerable<Product> 
    {
        public void Insert(string name, string brand_name, int cost)
        {
            int index = this.GetIndex(name);
            if (index == -1)//товар не найден
            {
                var new_product = new Product();
                new_product.name = name;
                base.Add(new_product);
                index = this.Count - 1;
            }
            this[index].Add(new Brand { name = brand_name, product_name = this[index].name, cost = cost });
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

        public bool Save_txt()
        {
            bool isFound = false;
            try
            {
                using (StreamWriter writen_to_file = new StreamWriter(@"d:\123.txt"))
                {
                    foreach (Product product in this)
                    {
                        foreach (Brand brand in product)
                        {
                            string epta = product.name + " " + brand.name + " " + brand.cost;
                            writen_to_file.WriteLine(epta);
                        }
                    }
                    var file = new FileInfo(@"d:\123.txt");
                    isFound = true;
                }
                return isFound;
            }
            catch (FileNotFoundException ex)
            {
                return isFound;
            }
        }

        public bool Open_txt()
        {
            bool isFound = false;
            try
            {
                using (StreamReader read = new StreamReader(@"d:\123.txt"))
                {
                    isFound = true;
                    string[] split;
                    string line = read.ReadLine();
                    while (line != null)
                    {
                        split = line.Split(' ');
                        Insert(split[0], split[1], Convert.ToInt32(split[2]));
                        line = read.ReadLine();
                    }
                }
                return isFound;
            }
            catch (FileNotFoundException ex)
            {
                return isFound;
            }
        }

        public bool BinarySave()
		{
            bool isFound = false;
            try
            {
                using (Stream File = new FileStream(@"D:\binary.bin", FileMode.Create))
                {
                    isFound = true;
                    using (BinaryWriter BinWr = new BinaryWriter(File))
                    {
                        foreach (Product product in this)
                        {
                            foreach (Brand brand in product)
                            {
                                string a = product.name + " " + brand.name + " " + brand.cost;
                                BinWr.Write(a);
                            }
                        }
                        BinWr.Write("End of File");
                        isFound = true;
                    }
                }
                return isFound;
            }
            catch (FileNotFoundException ex)
            {
                return isFound;
            }
        }

        public bool BinaryOpen()
        {
            bool isFound = false;
            try
            {
                using (Stream File = new FileStream(@"D:\binary.bin", FileMode.Open))
                {
                    using (BinaryReader BinRd = new BinaryReader(File))
                    {
                        string[] split;
                        string line = BinRd.ReadString();
                        while (line != "End of File")
                        {
                            split = line.Split(' ');
                            Insert(split[0], split[1], Convert.ToInt32(split[2]));
                            line = BinRd.ReadString();
                        }
                        isFound = true;
                    }                   
                }
                return isFound;
            }
            catch (FileNotFoundException ex)
            {
                return isFound;
            }

        }

        public bool Save_compression()
        {
            bool isFound = false;
            try
            {
                using (Stream s = File.Create(@"d:\compr.bin"))
                {
                    using (var ds = new DeflateStream(s, CompressionMode.Compress))
                    {
                        using (TextWriter writen_to_file = new StreamWriter(ds))
                        {
                            foreach (Product product in this)
                            {
                                foreach (Brand brand in product)
                                {
                                    string a = product.name + " " + brand.name + " " + brand.cost;
                                    writen_to_file.WriteLine(a);
                                }
                            }
                            isFound = true;
                        }
                    }
                }
                return isFound;
            }
            catch (FileNotFoundException ex)
            {
                return isFound;
            }
        }
        public bool Open_compression()
        {
            bool isFound = false;
            try
            {
                using (Stream s = File.OpenRead(@"d:\compr.bin"))
                {
                    using (var ds = new DeflateStream(s, CompressionMode.Decompress))
                    {
                        using (TextReader read = new StreamReader(ds))
                        {
                            string[] split;
                            string line = read.ReadLine();
                            while (line != null)
                            {
                                split = line.Split(' ');
                                Insert(split[0], split[1], Convert.ToInt32(split[2]));
                                line = read.ReadLine();
                            }
                            isFound = true;
                        }
                    }
                }
                return isFound;
            }
            catch (FileNotFoundException ex)
            {
                return isFound;
            }
        }

        string change = "Файл не был изменен";
        FileSystemWatcher watcher = new FileSystemWatcher();

        public void Watcher()
        {
            watcher.Path = @"d:\";
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.Changed += (s, e) =>
            {
                change = "Содержимое файла изменено";
            };
            watcher.EnableRaisingEvents = true;
        }

        public string Change_output()
        {
            watcher.EnableRaisingEvents = false;
            return change;
        }

        public bool CopyFile(string name)
        {
            bool isFound = false;
            try
            {
                var file = new FileInfo(@"d:\" + name);
                string[] naymushka = name.Split('.');
                file.CopyTo(@"d:\" + naymushka[0] + "copy." + naymushka[1]);
                isFound = true;
                return isFound;
            }
            catch (FileNotFoundException ex)
            {
                return isFound;
            }
        }

        public bool Rename(string name, string newName)
        {
            bool isFound = false;
            try
            {
                var file = new FileInfo(@"d:\" + name);
                File.Move(@"d:\" + name, @"d:\" + newName);
                isFound = true;
                return isFound;
            }
            catch (FileNotFoundException ex)
            {
                return isFound;
            }
        }
    }
}
