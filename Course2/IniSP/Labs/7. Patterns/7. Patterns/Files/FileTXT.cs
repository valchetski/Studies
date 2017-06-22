using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _7.Patterns
{
    class FileTXT : IReadWrite
    {
        public void Save(PhonesList phones)
        {
            using (StreamWriter writenToFile = new StreamWriter(@"FileTXT.txt"))
            {
                foreach (Phone phone in phones)
                {
                    writenToFile.WriteLine(phone.name);
                    writenToFile.WriteLine(phone.cost);
                    writenToFile.WriteLine(phone.color);
                    writenToFile.WriteLine(phone.key);
                }
                var file = new FileInfo(@"FileTXT.txt");
            }
        }
        public PhonesList Load()
        {
            using (StreamReader reader = new StreamReader(@"FileTXT.txt"))
            {
                var newPhones = new PhonesList();
                while (reader.Peek() > -1) //пока файл не закончился
                {
                    string name = reader.ReadLine();
                    double cost = Convert.ToDouble(reader.ReadLine());
                    string color = reader.ReadLine();
                    string key = reader.ReadLine();
                    var newPhone = new Phone(name, cost, color, key);
                    newPhones.Add(newPhone);
                }
                return newPhones;
            }
        }
    }
}
