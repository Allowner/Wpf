using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneBook
{
    public class ApplicationViewModel
    {
        ContactsContext db;
        Command addCommand, editCommand, deleteCommand, findCommand;

        public IEnumerable<Contact> Contacts
        {
            get;
            set;
        }

        public ApplicationViewModel()
        {
            db = new ContactsContext();
            db.Contacts.Load();
            Contacts = db.Contacts.Local.ToBindingList();
        }

        public Command AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new Command((o) =>
                  {
                      ContactWindow contactWindow = new ContactWindow(new Contact());
                      if (contactWindow.ShowDialog() == true)
                      {
                          Contact contact = contactWindow.Contact;
                          db.Contacts.Add(contact);
                          db.SaveChanges();
                      }
                  }));
            }
        }

        public Command EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new Command((selectedItem) =>
                  {
                      if (selectedItem == null)
                      {
                          return;
                      }

                      Contact contact = selectedItem as Contact;

                      Contact vm = new Contact()
                      {
                          Id = contact.Id,
                          Name = contact.Name,
                          Surname = contact.Surname,
                          Number = contact.Number,
                          Email = contact.Email
                      };

                      ContactWindow contactWindow = new ContactWindow(vm);

                      if (contactWindow.ShowDialog() == true)
                      {
                          contact = db.Contacts.Find(contactWindow.Contact.Id);
                          if (contact != null)
                          {
                              contact.Name = contactWindow.Contact.Name;
                              contact.Surname = contactWindow.Contact.Surname;
                              contact.Number = contactWindow.Contact.Number;
                              contact.Email = contactWindow.Contact.Email;
                              db.Entry(contact).State = EntityState.Modified;
                              db.SaveChanges();
                          }
                      }
                  }));
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new Command((selectedItem) =>
                  {
                      if (selectedItem == null)
                      {
                          return;
                      }

                      Contact contact = selectedItem as Contact;
                      db.Contacts.Remove(contact);
                      db.SaveChanges();
                  }));
            }
        }

        public Command FindCommand
        {
            get
            {
                return findCommand ??
                  (findCommand = new Command((tbx) =>
                  {
                      var contact = db.Contacts.Find(Convert.ToInt32(tbx));
                      var number = "No contact found";
                      if (contact != null)
                      {
                          number = $"Result number is: {contact.Number}";
                      }

                      MessageBox.Show(number, "Find contact",
                          MessageBoxButton.OK, MessageBoxImage.Information);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
