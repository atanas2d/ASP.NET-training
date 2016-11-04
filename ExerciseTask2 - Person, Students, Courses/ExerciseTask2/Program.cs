using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;

namespace ExerciseTask2
{
    class Program
    {

        private static void SelectAction()
        {
            Console.WriteLine("Welcome to Person Class Exercise 2!" +
                              "\nPlease choose module to test..." +
                              "\n1/ Constructors" +
                              "\n2/ People" +
                              "\n3/ Academy builder");

            string input;
            int choice = 0;

            do
            {
                Console.WriteLine("Enter value from 1 to 3: ");
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out choice) || choice < 1 || choice > 3);

            switch (choice)
            {
                case 1:
                    TestConstructors();
                    break;
                case 2:
                    TestPeople();

                    break;
                case 3:
                    TestAcadamyBuilder();
                    break;
            }
            ExitMethod();
        }

        static void TestConstructors()
        {
            Console.WriteLine("\nThis program will initialize Person with 3 different constructors.");

            Console.WriteLine("Please enter name of the Person: ");
            string personName = Console.ReadLine();

            int personAge = 1;
            string input;

            do
            {
                Console.WriteLine("Please enter age of the Person: ");
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out personAge) || personAge < 1);

            Person person1 = new Person();
            Person person2 = new Person(personName);
            Person person3 = new Person(personName, personAge);

            Console.WriteLine("\n" + person1.Name + " " + person1.Age);
            Console.WriteLine(person2.Name + " " + person2.Age);
            Console.WriteLine(person3.Name + " " + person3.Age);
        }

        private static void TestPeople()
        {
            Console.WriteLine("\nThis program will show you Persons older than 18, sorted by the length of teir name." +
                              "\nEnter the Name and Age of the Person in the following format: Peter//20" +
                              "\nEnter \"quit\" to finish and see the result.");

            string input;
            var persons = new List<Person>();

            do
            {
                Console.WriteLine("\nPlease name//age of a Person: ");
                input = Console.ReadLine();

                string[] resultArray = Regex.Split( input, "//");


                int age;

                if (resultArray.Length == 2 && Int32.TryParse(resultArray[1], out age))
                {
                    string name = resultArray[0];

                    persons.Add(new Person(name, age));

                    Console.WriteLine("You entered Person with name {0} and age {1}.", name, age);
                }

            } while (input != "quit");

            Console.WriteLine();

            var results = persons.Where((p1) => p1.Age > 18).OrderBy( (p1) => p1.Name.Length );

            foreach (var p in results) 
            {
                Console.WriteLine("{0} {1}", p.Name, p.Age);
            }

        }

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

        private static void ExitMethod()
        {
            Console.WriteLine();

            string input;

            do
            {
                Console.WriteLine("Do you want to keep testing modules? (y/n): ");
                input  = Console.ReadLine();
               
            } while (input != "y" && input != "n");

            if (input == "y")
            {
                SelectAction();
            }
            else if (input == "n")
            {
                Console.WriteLine("\nThank you! Have a nice day. Press any key to exit.");
                Console.ReadLine();
            }

        }

        static void Main(string[] args)
        {
            SelectAction();
        }
    }
}
