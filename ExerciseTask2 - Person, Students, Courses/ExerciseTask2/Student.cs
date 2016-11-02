using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTask2
{
    class Student : Person
    {
        private static int mIdNumber = 0;

        public int ID { get; private set; }

        private string FullName { get; set; }

        private int Age { get; set; }

        private Course course = null;

        private Course Course
        {
            get { return course; }

            set
            {
                if (this.course != null)
                {
                    throw new Exception("Student is already signed up");
                }
                else
                {
                    this.course = value;
                }
            } 
            
        }

        public Student() : base()
        {
            ID = mIdNumber++;
        }

        public Student(string fullName) : this()
        {
            this.FullName = fullName;
        }

        public Student(string fullName, int age) : this(fullName)
        {
            this.Age = age;
        }

        public void signCourse(Course course)
        {
            try
            {
                this.Course = course;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
