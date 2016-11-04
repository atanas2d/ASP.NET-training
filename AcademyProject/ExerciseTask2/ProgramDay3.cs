using ExerciseTask2.Education;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExerciseTask2
{
    partial class Program
    {
        private static void TestAcadamyBuilder()
        {
            Console.WriteLine("\nWelcome to the Acadamy builder." +
                              "\nThis program will let you enter courses and students and sign students for courses.");

            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();

            // Enter number of courses
            string input;
            int coursesNumber;

            do
            {
                Console.WriteLine("\nPlease enter number (integer) of courses in the Academy: ");
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out coursesNumber));

            // Enter courses data
            string[] resultArray;
            string courseName;
            double courseDuration;
            int courseCapacity;

            for (int i = 0; i < coursesNumber; i++)
            {
                do
                {
                    Console.WriteLine("\nPlease enter course {0} in format: courseName//duration//capacity", i + 1);

                    input = Console.ReadLine();
                    resultArray = Regex.Split(input, "//");
                } while (resultArray.Length != 3
                || !Double.TryParse(resultArray[1], out courseDuration)
                || !Int32.TryParse(resultArray[2], out courseCapacity));

                courseName = resultArray[0];

                Course newCourse = new Course(courseName, courseDuration, courseCapacity);
                courses.Add(newCourse);
            }

            Academy.Courses = courses;

            // Enter number of students
            int studentsNumber;
            do
            {
                Console.WriteLine("\nPlease enter number (integer) of students in the Academy: ");
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out studentsNumber));

            // Enter students data
            string studentName;
            int studentAge;

            for (int i = 0; i < studentsNumber; i++)
            {
                do
                {
                    Console.WriteLine("\nPlease enter student {0} in format: name//age", i + 1);

                    input = Console.ReadLine();
                    resultArray = Regex.Split(input, "//");
                } while (resultArray.Length != 2
                || !Int32.TryParse(resultArray[1], out studentAge));

                studentName = resultArray[0];

                Student student = new Student(studentName, studentAge);
                students.Add(student);
            }

            Academy.Students = students;

            Console.WriteLine("\n\nPlease sign students for courses in format: studentID courseID." +
                              "\n When finished with signing, enter \"quit\" to see the report.");

            do
            {
                int studentID = 0,
                    courseID = 0;

                input = Console.ReadLine();
                resultArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                while (resultArray.Length != 2
                    || !Int32.TryParse(resultArray[0], out studentID)
                    || !Int32.TryParse(resultArray[1], out courseID))
                {
                    if (input == "quit")
                    {
                        break;
                    }

                    Console.WriteLine("Please enter exactly 2 integers in format: studentID courseID");
                    input = Console.ReadLine();
                    resultArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                }

                try
                {
                    Academy.SignCourse(studentID, courseID);
                }
                catch (Exception ex)
                {
                    // Get stack trace for the exception with source file information
                    var st = new StackTrace(ex, true);
                    // Get the top stack frame
                    var frame = st.GetFrame(0);
                    // Get the line number from the stack frame
                    int line = frame.GetFileLineNumber();

                    Console.WriteLine("Error: {0}", ex.Message);
                    Console.WriteLine("Line number of error: {0}", line);
                }


            } while (input != "quit");

            Console.WriteLine();
            foreach (var course in Academy.Courses.OrderBy(c => c.Name))
            {
                Console.WriteLine(course.Name);
                foreach (var student in course.Students.OrderBy(s => s.Name))
                {
                    Console.WriteLine("##" + student);
                }
                Console.WriteLine();
            }

        }
    }
}
