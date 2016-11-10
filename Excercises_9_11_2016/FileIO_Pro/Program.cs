using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO_Pro
{
    class Program
    {
        static void Main(string[] args)
        {
            FileIO fileService = new FileIO();

            fileService.CopyFile("../../test1.txt", "../../test2.txt");
        }
    }
}
