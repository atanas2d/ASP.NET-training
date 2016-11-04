using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTask2
{
    class PersonAgeException : Exception
    {
        public PersonAgeException(string message) : base(message)
        {
            
        }
    }
}
