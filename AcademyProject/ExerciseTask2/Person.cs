using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTask2
{
    class Person
    {
        private int age;

        public string Name { get; set; }

        public int Age
        {
            get { return age; }

            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    throw new PersonAgeException("Ages should be positive integer.");
                }
            }
        }

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(string name) : this()
        {
            this.Name = name;
        }

        public Person(string name, int age) : this(name)
        {
            this.Age = age;
        }

    }
}
