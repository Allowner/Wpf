using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure
{
    public class SqliteRepository : IRepository<Contact>
    {
        private ContactsContext db;

        public SqliteRepository()
        {
            this.db = new ContactsContext();
            db.Contacts.Load();
        }

        public IEnumerable<Contact> GetList()
        {
            return db.Contacts.Local.ToBindingList();
        }

        public Contact Get(int id)
        {
            return db.Contacts.Find(id);
        }

        public void Create(Contact contact)
        {
            db.Contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
        }

        public void Delete(Contact contact)
        {
            db.Contacts.Remove(contact);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
