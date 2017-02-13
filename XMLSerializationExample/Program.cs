using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerializationExample
{
    [Serializable]
    public class Student
    {
        public string name;
        public string sname;
        public double gpa;
        public Student(string name, string sname)
        {
            this.name = name;
            this.sname = sname;
        }

        public Student()
        {
            this.name = "John";
            this.sname = "Smith";
            this.gpa = 4.0;
        }

        public void Generate()
        {
           
        }

        public override string ToString()
        {
            return string.Format("name:{0}, sname:{1}, gpa:{2}", name, sname, gpa);
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {

            XmlSerializer xs = new XmlSerializer(typeof(Student));
            /*Student s = new Student("AA","BBB");
            FileStream fs = new FileStream("student.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //s.name = "John" + Environment.NewLine +  "Ali";
            //s.sname = "Smith";

            xs.Serialize(fs, s);

            fs.Close();*/
            Student s2 = new Student();
            FileStream fs2 = new FileStream("student.txt", FileMode.Open, FileAccess.Read);
            s2 = xs.Deserialize(fs2) as Student;
            //Console.WriteLine(s2);
            fs2.Close();


            Student s3 = new Student();
            Student s4 = new Student();
            
            MemoryStream ms = new MemoryStream();
            xs.Serialize(ms, s3);
            ms.Seek(0, SeekOrigin.Begin);
            s4 = xs.Deserialize(ms) as Student;

            Console.WriteLine(s3);
            s3.sname = "ABC";
            Console.WriteLine(s4);

            
        }
    }
}
