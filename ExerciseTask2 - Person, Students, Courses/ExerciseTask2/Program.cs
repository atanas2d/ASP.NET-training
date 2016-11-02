using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExerciseTask2
{
    class Program
    {
        private int choice;
        
        private int Choice { get; set; }

        static void testConstructors()
        {
            Console.WriteLine("This program will initialize Person with 3 different constructors.");

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

        private static void selectAction()
        {
            Console.WriteLine("Welcome to Person Class Exercise 2!" +
                              "\nPlease choose module to test..." +
                              "\n1/ Constructors" +
                              "\n2/ People" +
                              "\n3/ Course and Students objects");

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
                    testConstructors();
                    break;
                case 2:
                    testPeople();
                    break;
                case 3:
                    testCourseAndStudentsObjects();
                    break;
            }
        }

        private static void testPeople()
        {
            Console.WriteLine("This program will show you Persons older than 18, sorted by the length of teir name." +
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

        private static void testCourseAndStudentsObjects()
        {
            
        }

        private static void exitMethod()
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
                selectAction();
            }
            else if (input == "n")
            {
                Console.WriteLine("\nThank you! Have a nice day. Press any key to exit.");
                Console.ReadLine();
            }

        }

        static void Main(string[] args)
        {
            selectAction();

            exitMethod();
        }
    }
}
