using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLAffair
{
    public class Student
    {
        private static int _Id = 0;

        public Student()
        {
            this.Name = "No name";
            Age = 1;
        }

        public Student(string name, int age)
        {
            Id = _Id++;
            Name = name;
            Age = age;
        }

        public int Id { get; set;
        }

        public string Name { get; set; }

        public int Age { get; set; }

    }
}
