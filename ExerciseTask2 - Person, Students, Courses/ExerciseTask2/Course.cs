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

        public int ID { get; private set; }

        public string Name { get; set; }

        public double Hours { get; set; }

        public int Capacity { get; set; } = 0;

        private List<Student> mStudents = new List<Student>();

        public List<Student> Students
        {
            get { return this.mStudents; }
            set {
                if (value is IList<Student>
                    && value.Count <= this.Capacity)
                {
                    this.mStudents = value;
                }
            }
        }

        public Course(string name, double hours, int capacity)
        {
            ID = ++mIdNumber;

            this.Name = name;
            this.Hours = hours;
            this.Capacity = capacity;
        }

        public void AddStudent(Student student)
        {
            if (!Students.Exists((s) => student.ID == s.ID))
            {
                Students.Add(student);
            }
        }

        public void RemoveStudent(int studentID)
        {
            foreach (var s in this.Students)
            {
                if (studentID == s.ID)
                {
                    this.Students.Remove(s);
                }
            }
        }

        public List<Student> FindStudents(string[] names)
        {
            List<Student> results = null;

            foreach (string name in names)
            {
                List<Student> foundStudents = this.Students.Where((s) => s.Name.Contains(name)).ToList();

                foundStudents.ForEach(s => results.Add(s));
            }

            return results;
        }

        public bool Equals(Course course)
        {
            // If parameter is null return false.
            if (course == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ID == course.ID) && (Name == course.Name) && (Hours == course.Hours) && (Capacity == course.Capacity);
        }

        public override string ToString()
        {
            return Name + " - " + Hours;
        }

    }
}
