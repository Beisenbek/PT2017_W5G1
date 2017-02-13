using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using XMLSerializationExample;

namespace BinaryFormatterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student  s = new Student();
            s.Generate();
            
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("student.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                bf.Serialize(fs, s);
            }

        }
    }
}
