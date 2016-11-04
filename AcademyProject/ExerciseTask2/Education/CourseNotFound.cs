using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTask2.Education
{
    class CourseNotFound : Exception
    {
        public CourseNotFound(string message) : base(message)
        {
            
        }
    }
}
