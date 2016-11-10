using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Serialization;

namespace Contacts
{
    public interface IReader
    {
        IList<T> Read<T>();
    }
}