using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication35
{
    class Program
    {
        static void PrintMatrix (int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter dimensions:");
            var input = Console.ReadLine();
            int length;

            while (!Int32.TryParse(input, out length))
            {
                if (input == "exit")
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Enter dimensions:");
                input = Console.ReadLine();
                
            }

            int[][] matrix = new int[length][];
            int counter = 0;

            for (int i = 0; i < length; i++)
            {                
                matrix[i] = new int[length];

                for (int j = 0; j < length; j++)
                {   
                    matrix[i][j] = counter++;                    
                }
            }

            PrintMatrix(matrix);

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            do
            {
                Console.WriteLine("Pleaes enter x y coordiantes to increment: ");
                input = Console.ReadLine();

                if (input == "exit")
                {
                    Environment.Exit(0);
                }

                string[] splits = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                
                while (splits.Length != 2)
                {
                    Console.WriteLine("Please enter exactly {0} values: ", 2);
                    input = Console.ReadLine();
                    if (input == "exit")
                    {
                        Environment.Exit(0);
                    }

                    splits = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                }

                int[] coordinates = new int[2];                  

                bool isInteger = true;

                do
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (!Int32.TryParse(splits[i], out coordinates[i])) {
                            isInteger = false;
                        }
                    }

                    if (!isInteger)
                    {
                        Console.WriteLine("Enter proper integer coordinates: ");
                        Console.ReadLine();
                        isInteger = true;
                    } else
                    {   
                        matrix[coordinates[0]][coordinates[1]]++;
                        PrintMatrix(matrix);
                    }

                } while (!isInteger );
                                                                
            }

            while (input.Length > 0);

            Console.WriteLine("Thank you.");
            Console.ReadLine();
            
        }
    }
}
