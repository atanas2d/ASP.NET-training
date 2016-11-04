using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTask2.Education
{
    class Student : Person
    {
        private static int mIdNumber = 0;

        public int ID { get; private set; }

        private string FullName { get; set; }

        private int Age { get; set; }

        private Course mCourse;

        public Course Course
        {
            get { return mCourse; }

            set
            {
                if (mCourse != null)
                {
                    throw new Exception("Student is already signed up");
                }
                else
                {
                    mCourse = value;
                }
            } 
        }

        public Student() : base()
        {
            ID = ++mIdNumber;
        }

        public Student(string fullName) : this()
        {
            this.FullName = fullName;
        }

        public Student(string fullName, int age) : this(fullName)
        {
            this.Age = age;
        }

        public bool Equals(Student student)
        {
            // If parameter is null return false.
            if (student == null)
            {
                return false;
            }
            
            // Return true if the fields match:
            return (ID == student.ID) && (Name == student.Name) && (Age == student.Age);
        }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
