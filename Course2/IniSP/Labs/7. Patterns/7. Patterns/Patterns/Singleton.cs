using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Patterns
{
    public sealed class Singleton
    {
        private Singleton() { } //конструктор у Singleton должен быть private

        private static Singleton instance;    
        public static Singleton GetInstance()//метод для получения объекта класса Singleton
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
        public string GetKey(string name)
        {
            return ((name.GetHashCode()).ToString());
        }
    }
}
