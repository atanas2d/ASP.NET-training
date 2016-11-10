using System.Collections.Generic;

namespace Contacts
{
    internal interface ISerializer
    {
        string Serialize<T>(IEnumerable<T> collection, string output, string  type);
    }

}