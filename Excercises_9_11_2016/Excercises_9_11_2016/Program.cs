using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Excercises_9_11_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] words = input.Split();

            Dictionary<string, int> topWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!topWords.ContainsKey(word.ToLower()))
                {
                    topWords[word.ToLower()] = 1;
                }
                else
                {
                    topWords[word.ToLower()]++;
                }
            }

            foreach (var pretendent in topWords.OrderByDescending(w => w.Value))
            {
                Console.WriteLine($"{pretendent.Key} is use {pretendent.Value} times.");
            }

            Console.ReadLine();
        }
    }
}
   