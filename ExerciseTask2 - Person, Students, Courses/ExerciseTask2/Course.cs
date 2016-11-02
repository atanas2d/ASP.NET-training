using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ExerciseTask2
{
    class Course
    {
        private static int mIdNumber = 0;

        public static int ID => mIdNumber;

        private string Name { get; set; }

        private double Hours { get; set; }

        private int Capacity { get; set; }

        private List<Student> mStudents;

        private List<Student> Students
        {
            get { return this.mStudents; }
            set {
                if (typeof(Student) == value.GetType().GetElementType())
                {
                    this.mStudents = value;
                }
            }
        }

        public Course(string name, double hours, int capacity)
        {
            mIdNumber++;

            this.Name = name;
            this.Hours = hours;
            this.Capacity = capacity;
        }

        public void AddStudent(Student student)
        {
            if (!this.Students.Contains(student))
            {
                this.Students.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            foreach (var s in this.Students)
            {
                if (student.ID == s.ID)
                {
                    this.Students.Remove(s);
                }
            }
        }

        public List<Student> FindStudent(string name)
        {
            return this.Students.Where((s) => s.Name.Contains(name)).ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
