using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class ContactsContext : DbContext
    {
        public ContactsContext() : base("DefaultConnection")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
