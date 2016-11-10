using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XMLAffair
{
    class Academy
    {
        private List<Student> students = new List<Student>();

        public void CreateStudent(string name, int age)
        {
            Student student = new Student(name, age);
            students.Add(student);
        }

        public void RecordToXML(string filename = "../../students.xml")
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            StringWriter writer = new StringWriter();
            string output = "";

            using (XmlWriter xmlWriter = XmlWriter.Create("../../xmlStudent.xml"))
            {
                serializer.Serialize(xmlWriter, students);
                Console.WriteLine(output);
            }

            XmlDocument document = new XmlDocument();

            XmlNode root = document.CreateElement("root");
            document.AppendChild(root);

            XmlNode studentsNode = document.CreateElement("students");
            root.AppendChild(studentsNode);

            foreach (var student in students)
            {
                XmlElement studentElement = document.CreateElement("student");
                studentElement.SetAttribute("Name", student.Name);
                studentElement.SetAttribute("Age", student.Age.ToString());
                studentElement.SetAttribute("Id", student.Id.ToString());

                studentsNode.AppendChild(studentElement);
            }

            document.Save(filename);

        }
    }
}
