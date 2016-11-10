using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLAffair
{
    class Program
    {
        static void Main(string[] args)
        {
            Academy academy = new Academy();

            academy.CreateStudent("Nasko", 33);
            academy.CreateStudent("Ivo", 30);
            academy.CreateStudent("Pesho", 20);

            academy.RecordToXML();

        }
    }
}
