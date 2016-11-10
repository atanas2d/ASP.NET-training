using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("../../text.txt", true, Encoding.UTF8))
            {
                writer.WriteLine("Hi from program");
                writer.WriteLine("Second Hi");
                writer.Close();
            }

            using (StreamReader reader = new StreamReader("../../text.txt", Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("I red: " + line);
                }
            }
        }
    }
}
