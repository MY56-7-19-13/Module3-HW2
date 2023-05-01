using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Contact : IComparable<Contact>
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public Contact(string name, string number)
        {
            Name = name;
            Number = number;
        }

        public int CompareTo(Contact? other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
