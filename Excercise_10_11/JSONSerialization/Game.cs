using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    class Game
    {
        public Game(string provider, string provideGameUrl, string gameUrl)
        {
            Id = Guid.NewGuid();
            Provider = provider;
            ProviderGameUrl = ProviderGameUrl;
            GameUrl = gameUrl;
        }

        public Guid Id { get; set; }

        public string Provider { get; set; }

        public string ProviderGameUrl { get; set; }

        public string GameUrl { get; set; }

    }
}
