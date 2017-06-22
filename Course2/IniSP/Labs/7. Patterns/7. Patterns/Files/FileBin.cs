using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _7.Patterns
{
    class FileBin : IReadWrite
    {
        public void Save(PhonesList phones)
        {
            var formatter = new BinaryFormatter();
            using (Stream stream = File.Create(@"FileBin.bin"))
                formatter.Serialize(stream, phones);
        }
        public PhonesList Load()
        {
            var formatter = new BinaryFormatter();
            var newPhones = new PhonesList();
            using (Stream stream = File.OpenRead(@"FileBin.bin"))
            {
                newPhones = (PhonesList)formatter.Deserialize(stream);
            }
            return newPhones;
        }
    }
}
