using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSONSerialization
{
    class Program
    {
        static void Main(string[] args)
        {

            Game game = new Game("blizzard", "blizzardcasino.com", "onlinecasino.com");

            string json = JsonConvert.SerializeObject(game, Formatting.Indented);

            Console.WriteLine(json.ToString());

            var newGame = JsonConvert.DeserializeObject<Game>(json);

            Console.WriteLine(newGame.Id);

            Console.WriteLine("aze narcisa".Contains("ze"));
        }
    }
}
