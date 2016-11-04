using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;
using ExerciseTask2.Education;

namespace ExerciseTask2
{
    partial class Program
    {

        private static void SelectAction()
        {
            Console.WriteLine("Welcome to Person Class Exercise 2!" +
                              "\nPlease choose module to test..." +
                              "\n1/ Constructors" +
                              "\n2/ People" +
                              "\n3/ Academy builder" +
                              "\n4/ Test Complex numbers operations.");

            string input;
            int choice = 0;

            do
            {
                Console.WriteLine("Enter value from 1 to 4: ");
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out choice) || choice < 1 || choice > 4);

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
                case 4:
                    TestComplexConsole();
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
