using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerializationExample
{
    public class Student
    {
        public string name;
        public string sname;
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            Student s = new Student();
            FileStream fs = new FileStream("student.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            s.name = "John";
            s.sname = "Smith";

            //xs.Serialize(fs, s);

            fs.Close();

            Student s2 = new Student();
            FileStream fs2 = new FileStream("student.txt", FileMode.Open, FileAccess.Read);
            s2 = xs.Deserialize(fs2) as Student;

            Console.WriteLine(s2.name + " " + s2.sname);

            fs2.Close();
        }
    }
}
