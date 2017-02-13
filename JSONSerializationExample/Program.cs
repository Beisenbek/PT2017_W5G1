using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLSerializationExample;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace JSONSerializationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("AAA","BBBB");
           // s.Generate();

            string res = JsonConvert.SerializeObject(s);

            using (FileStream ds = new FileStream("student.json", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(ds))
                {
                    sw.WriteLine(res);
                }
            }
            /*
            using (FileStream ds = new FileStream("student.json", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sw = new StreamReader(ds))
                {
                    string text = sw.ReadToEnd();
                    Console.WriteLine(text);
                    Student s2 = JsonConvert.DeserializeObject<Student>(text);
                    Console.WriteLine(s2.name);
                    Console.WriteLine(s2.sname);
                    Console.WriteLine(s2.gpa);
                }
            }*/

          
        }
    }
}
