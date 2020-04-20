using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public long Number { get; set; }

        public string Email { get; set; }
    }
}
