using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts
{
    class Serializer : ISerializer
    {
        private IEnumerable<T> data;
        private string serializationType;

        Serializer(IEnumerable<T> data, string serializationType)
        {
            this.data = data;
            this.serializationType = serializationType;
        }

        public string Serialize()
        {
            switch (serializationType.ToLower())
            {
                case "json":

                    return JsonConvert.SerializeObject(data, Formatting.Indented);
                case "xml":

                    return "";
            }

            return null;
        }
    }
}
