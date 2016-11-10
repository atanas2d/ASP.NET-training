using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    class Serializer : ISerializer
    {
        public string Type { get; set; }

        public string Serialize<Contact>(IEnumerable<Contact> contacts, string fileName, string serializationType)
        {
            switch (serializationType.ToLower())
            {
                case "json":
                    string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
                    break;
                case "xml":
                    return "";
            }

            return null;
        }


    }
}
