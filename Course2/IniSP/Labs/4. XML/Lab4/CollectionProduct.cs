using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace Lab4
{
    [Serializable]
    public class CollectionProduct : List<Product>, IDisposable, IEnumerable<Product>
    {
        public void SaveXML()
        {
            var declaration = new XDeclaration("1.0", "utf-8", "yes");
            var documentXML = new XDocument(declaration, new XElement("ArrayOfBrand"));
            foreach (Product product in this)
            {
                foreach (Brand brand in product)
                {
                    var newXElement = new XElement("Brand");
                    var productNameXML = new XElement("product_name", product.name);
                    var brandNameXML = new XElement("name", brand.name);
                    var brandcostXML = new XElement("cost", brand.cost);
                    newXElement.Add(productNameXML, brandNameXML, brandcostXML);
                    if (documentXML.Root != null)
                    {
                        documentXML.Root.Add(newXElement);
                    }
                }
            }
            documentXML.Save(@"d:\purchase.xml", SaveOptions.None);
        }

        public void OpenXML()
        {
            var settings = new XmlReaderSettings {IgnoreComments = true, IgnoreWhitespace = true};
            using (var documentXML = XmlReader.Create(@"d:\purchase.xml", settings))
            {
                var newBrand = new List<string>();
                while (documentXML.Read())
                {
                    switch (documentXML.NodeType)
                    {
                        case XmlNodeType.Element:
                            continue;
                        case XmlNodeType.EndElement:
                            if (documentXML.Name == "Brand")
                            {
                                if (newBrand != (new List<string>()))
                                    Insert(newBrand[0], newBrand[1], Convert.ToInt32(newBrand[2]));
                                newBrand = new List<string>();
                            }
                            break;
                        case XmlNodeType.Text:
                            newBrand.Add(documentXML.Value);
                            break;
                    }
                }
            }
        }

        public void SerializeBin()
        {
            var formatter = new BinaryFormatter();
            using (Stream s = File.Create(@"d:\purchase.bin"))
                formatter.Serialize(s, this);
        }

        public void DeserializeBin()
        {
            var formatter = new BinaryFormatter();
            CollectionProduct newCollection;
            using (Stream s = File.OpenRead(@"d:\purchase.bin"))
            {
                newCollection = (CollectionProduct)formatter.Deserialize(s);
            }
            foreach (Product product in newCollection)
            {
                foreach (Brand brand in product)
                {
                    Insert(brand.productName, brand.name, brand.cost);
                }
            }
        }

        public void SerializeXML()
        {
            var serializer = new XmlSerializer(typeof(CollectionProduct));
            Stream writer = new FileStream(@"d:\purchaseSerial.xml", FileMode.Create);
            serializer.Serialize(writer, this);
            writer.Close();
        }

        public void DeserializeXML()
        {
            var serializer = new XmlSerializer(typeof(CollectionProduct));
            Stream reader = new FileStream(@"d:\purchaseSerial.xml", FileMode.Open);
            var newCollection = (CollectionProduct)serializer.Deserialize(reader);
            foreach (Product product in newCollection)
            {
                foreach (Brand brand in product)
                {
                    Insert(brand.productName, brand.name, brand.cost);
                }
            }
        }

        public bool IsFound(string searchProduct, string searchBrand)
        {
            var settings = new XmlReaderSettings {IgnoreComments = true, IgnoreWhitespace = true};
            using (var documentXML = XmlReader.Create(@"d:\purchase.xml", settings))
            {
                bool boolka = documentXML.Read();
                while (boolka)
                {
                    if (documentXML.NodeType == XmlNodeType.Element)
                    {
                        if (documentXML.Name == "product_name")
                        {
                            documentXML.Read();
                            if (documentXML.Value == searchProduct)
                            {
                                documentXML.Read();
                                documentXML.Read();
                                if (documentXML.Name == "name")
                                {
                                    documentXML.Read();
                                    if (documentXML.Value == searchBrand)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    boolka = documentXML.Read();
                }
            }
            return false;
        }

        public void SerializeContract()
        {
            var ds = new DataContractSerializer(typeof(CollectionProduct));
            using (Stream s = File.Create(@"d:\contract.xml"))
            {
                ds.WriteObject(s, this);
            }
        }

        public void DeserializeContract()
        {
            var ds = new DataContractSerializer(typeof(CollectionProduct));
            CollectionProduct newCollection;
            using (Stream s = File.OpenRead(@"d:\contract.xml"))
            {
                newCollection = (CollectionProduct) ds.ReadObject(s);
            }
            foreach (Product product in newCollection)
            {
                foreach (Brand brand in product)
                {
                    Insert(brand.productName, brand.name, brand.cost);
                }
            }
        }
        public void Insert(string newName, string brandName, int newCost)
        {
            int index = GetIndex(newName);
            if (index == -1)//товар не найден
            {
                var newProduct = new Product {name = newName};
                Add(newProduct);
                index = Count - 1;
            }
            this[index].Add(new Brand { name = brandName, productName = this[index].name, cost = newCost });
            this[index] = this[index].Sort();
        }

        public string Print_all()
        {
            string result = "";
            bool productsFound = false;
            foreach (Product product in this)
            {
                result += product.name + ":\n";
                foreach (Brand brand in product)
                {
                    result += "\t" + brand.name + " " + brand.cost + "руб\n";
                }
                productsFound = true;
            }
            if (productsFound)
                return ("Все товары:\n" + result);
            return "Товаров в покупке нет!:(";
        }

        public string Delete(string deleteProduct)
        {
            bool isFound = Delete1(deleteProduct);
            string result = "Этого экземпляра товара нет в списке покупок!";
            while (isFound)
            {
                isFound = Delete1(deleteProduct);
                result = "Удаление прошло успешно";
            }
            return result;
        }

        public bool Delete1(string deleteProduct)
        {
            int j = 0;
            foreach (Product product in this)
            {
                foreach (Brand brand in product)
                {
                    if (brand.name == deleteProduct)
                    {
                        this[j].Remove(brand);
                        if (this[j].Count == 0)
                            Remove(product);
                        return true;
                    }
                }
                j++;
            }
            return false;
        }

        public int GetIndex(string searchProduct)
        {
            int index = 0;
            bool found = false;
            foreach (Product product in this)
            {
                if (product.name == searchProduct)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (!found)
                return (-1);
            return index;
        }

        public string Search(string searchProduct)
        {
            int index = 0;
            bool found = false;
            foreach (Product product in this)
            {
                if (product.name == searchProduct)
                {
                    found = true;
                    break;
                }
                index++;
            }
            if (found)
            {
                string result = ("Результаты поиска:\n" + this[index].name + ":\n");
                foreach (Brand brand in this[index])
                {
                    result += ("\t" + brand.name + " " + brand.cost + "руб\n");
                }
                return result;
            }
            return ("Товар не найден!");
        }

        public string Filter(int filtrusha)
        {
            string result = "";
            foreach (Product product in this)
            {
                string tempResult = product.Filter(filtrusha);
                if (tempResult != "")
                    result += product.name + ":\n\t" + tempResult;
            }
            if (result != "")
                return result;
            return null;
        }

        public string Projection()
        {
            string result = "";
            var nameList = this.Select(product => product.name);
            foreach (string name in nameList)
            {
                result += "\t" + name + "\n";
            }
            return result;
        }

        public void Dispose()//реализую интерфейс IDisposable
        {
            Clear();
        }

        ~CollectionProduct()//финализатор
        {
            Dispose();
        }

        public new IEnumerator<Product> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }

        internal void Change(string searchProduct, string searchBrand, int newCost)
        {
            throw new NotImplementedException();
        }
    }
}
