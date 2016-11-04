using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ExerciseTask2.Education
{
    class Course
    {
        private static int mIdNumber = 0;

        public int ID { get; }

        public string Name { get; set; }

        public double Hours { get; set; }

        public int Capacity { get; set; } = 0;

        private List<Student> mStudents = new List<Student>();

        public List<Student> Students
        {
            get { return this.mStudents; }
            set {
                if (value.Count <= this.Capacity)
                {
                    this.mStudents = value;
                }
                else
                {
                    throw new Exception("Course " + Name + " capacity is full. No more students can be added.");
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
                if (Capacity > Students.Count)
                {
                    Students.Add(student);
                }
                else
                {
                    throw new Exception("Course " + Name + " capacity is full. No more students can be added.");
                }
                
            }
        }

        public void RemoveStudent(int studentID)
        {
            foreach (var s in this.Students)
            {
                if (studentID == s.ID)
                {
                    this.Students.Remove(s);
                    break;
                }
            }
        }

        public List<Student> FindStudents(string[] names)
        {
            List<Student> results = new List<Student>();

            foreach (string name in names)
            {
                results.AddRange(Students.Where((s) => s.Name.Contains(name)).ToList());
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
