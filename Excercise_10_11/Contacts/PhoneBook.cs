using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    class PhoneBook
    {
        private HashSet<Contact> _contacts = new HashSet<Contact>();

        public PhoneBook()
        {
            
        }

        public void Add(string name, string town, string phone)
        {
            Contact contact = new Contact(name, town, phone);
            _contacts.Add(contact);
        }

        public List<Contact> find(string name, string town = null)
        {
            if (town != null)
            {
                return _contacts.Where(c => c.Name.Contains(name) && c.Town.Contains(town)).ToList();
            }


            return _contacts.Where(c => c.Name.Contains(name)).ToList();
        }

        public void Serialize(ISerializer serializer)
        {
            
        }

        public HashSet<Contact> readContacts(IReader reader)
        {
            return new HashSet<Contact>(reader.Read<Contact>());
        }
    }
}
