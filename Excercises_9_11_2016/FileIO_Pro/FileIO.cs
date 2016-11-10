using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO_Pro
{
    class FileIO
    {
        public Encoding Encoding { get; set; }

        public FileIO(Encoding encoding = null)
        {
            Encoding = encoding;
        }

        public List<string> readFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string line;
                List<string> result = new List<string>();
                while ((line = reader.ReadLine()) != null)
                {
                    result.Add(line);
                }

                return result;
            }
        }

        public void WriteFile(string filePath, List<string> input)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                foreach (var line in input)
                {
                   writer.WriteLine(line);
                }
                writer.Close();
            }
        }

        public void CopyFile(string fileNameToRead, string fileNameToWrite)
        {
            List<string> data = readFile(fileNameToRead);
            WriteFile(fileNameToWrite, data);
        }
    }
}
