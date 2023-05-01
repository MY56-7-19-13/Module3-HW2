using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class PhoneBookCollection
    {
        private CultureInfo? cultureInfo;
        List<Contact> _contacts { get; set; } = new List<Contact>();
        public PhoneBookCollection(List<Contact> contacts)
        {
            _contacts = contacts;
        }


        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }
        public void GetAllContacts()

        {
            Console.WriteLine("Contacts:");
            GetContactDetails(_contacts);
        }
        private void ShowContactDetails(Contact contact)
        {
            Console.WriteLine($"Name: {contact.Name} | Number: {contact.Number}");
        }
        private void GetContactDetails(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                ShowContactDetails(contact);
            }
        }
        public void SearchContact(string search)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts[i] == null)
                {
                    Console.WriteLine("NULL");
                }
                else if (search.Equals(_contacts[i].Name))
                {
                    var searchContact = _contacts[i];
                    ShowContactDetails(searchContact);
                }
            }
        }
        public string GroupKey(string name, string culture)
        {
            string groupKey;
            if (culture == "ua")
            {
                CultureInfo cultureInfo = new CultureInfo("uk-Ua");
            }
            else
            {
                CultureInfo cultureInfo = new CultureInfo("en-Us");
            }
            if (char.IsDigit(name[0]))
            {
                groupKey = "0-9";
            }
            else
            {
                groupKey = name.Substring(0, 1).ToUpper(cultureInfo);
            }
            return groupKey;
        }
    }
}
