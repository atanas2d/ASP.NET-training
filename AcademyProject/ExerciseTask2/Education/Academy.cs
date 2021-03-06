﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ExerciseTask2.Education
{
    class Academy
    {
        public static List<Student> Students { get; set; }

        private static List<Course> mCourses;

        public static List<Course> Courses
        {
            get { return mCourses; }
            set
            {
                if (value is IList<Course>)
                {
                    mCourses = value;
                }
            }
        }

        public static List<Task> Tasks { get; set; }
        
        public static void AddStudent(Student student)
        {
            bool isStudentExists = false;
            foreach (var s in Students)
            {
                if (s.Equals(student))
                {
                    isStudentExists = true;
                }
            }
            if (!isStudentExists)
            {
                Students.Add(student);
            }
        }

        public static void RemoveStudent(int studentID)
        {
            foreach (var s in Students)
            {
                if (s.ID == studentID)
                {
                    Students.Remove(s);
                }
            }
        }

        public static void AddCourse(Course course)
        {
            if (!Courses.Exists((c) => c.ID == course.ID))
            {
                mCourses.Add(course);
            }
        }

        public static void RemoveCourse(int courseID)
        {
            foreach (var course in Courses)
            {
                if (course.ID == courseID)
                {
                    mCourses.Remove(course);
                }
            }
        }

        public static void SignCourse(int studentID,  int courseID)
        {
            Student student = Students.FirstOrDefault((s) => s.ID == studentID);
            if (student == null)
            {
                throw new StudentNotFound("Student with ID " + studentID + " does not exists.");
            }

            Course course = Courses.FirstOrDefault((c) => c.ID == courseID);
            if (course == null)
            {
                throw new CourseNotFound("Course with ID " + courseID + " does not exists.");    
            }
            
            student.Course = course;
            course.AddStudent(student);
        }


    }
}
