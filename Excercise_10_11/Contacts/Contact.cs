using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    class Contact : Person, IEqualityComparer<Contact>
    {
        public Contact(string name, string town, string phone) : base(name)
        {
            Town = town;
            Phone = phone;
        }

        public string Town { get; set; }

        public string Phone { get; set; }
        
        public bool Equals(Contact x, Contact y)
        {
            return x.Phone.ToLower() == y.Phone.ToLower();
        }

        public int GetHashCode(Contact obj)
        {
            return obj.Phone.GetHashCode();
        }
    }
}
