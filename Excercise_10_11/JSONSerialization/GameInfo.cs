using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONSerialization
{
    class GameInfo
    {
        public GameInfo()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
