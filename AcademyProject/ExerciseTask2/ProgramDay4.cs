using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTask2
{
    public partial class Program
    {
        public static void TestComplexConsole()
        {
            Console.WriteLine("\nHello, user! Welcome to Complex numbers add and substract test." +
                              "\nPleae enter 2 lines of complex numbers in format: 2 3 /for number: 2 3i/" +
                              "\nOn lne 3 enter \"add\" or \"sub\"");

            Complex[] numbers = new Complex[2];

            for (int i = 0; i < 2; i++)
            {

                string[] result;

                int real, imaginary;

                do
                {
                    Console.WriteLine("Enter {0} complex number: ", i + 1);

                    string input = "";

                    input = Console.ReadLine();

                    result = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                } while (result.Length != 2
                || !Int32.TryParse(result[0], out real)
                || !Int32.TryParse(result[1], out imaginary));

                numbers[i] = new Complex(real, imaginary);
            }

            string operation;
            do
            {
                Console.WriteLine("Enter operation (add/sub):");
                operation = Console.ReadLine();

            } while (operation != "add" && operation != "sub");

            // output
            Complex complexResult = numbers[0];

            switch (operation)
            {
                case "add":
                    foreach (var number in numbers.Skip(1))
                    {
                        complexResult += number;
                    }
                    Console.WriteLine(complexResult);
                    break;
                case "sub":
                    foreach (var number in numbers.Skip(1))
                    {
                        complexResult -= number;
                    }
                    Console.WriteLine(complexResult);
                    break;
            }
        }

        public static void TestGrades()
        {
            
        }

    }
}
