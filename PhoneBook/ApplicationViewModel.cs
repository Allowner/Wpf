using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PhoneBook.Infrastructure;

namespace PhoneBook
{
    public class ApplicationViewModel
    {
        private readonly IRepository<Contact> repository;
        private Command addCommand, editCommand, deleteCommand, findCommand;

        public IEnumerable<Contact> Contacts
        {
            get;
            set;
        }

        public ApplicationViewModel(IRepository<Contact> repository)
        {
            this.repository = repository;
            Contacts = repository.GetList();
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
                          repository.Create(contact);
                          repository.Save();
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
                          contact = repository.Get(contactWindow.Contact.Id);
                          if (contact != null)
                          {
                              contact.Name = contactWindow.Contact.Name;
                              contact.Surname = contactWindow.Contact.Surname;
                              contact.Number = contactWindow.Contact.Number;
                              contact.Email = contactWindow.Contact.Email;
                              repository.Update(contact);
                              repository.Save();
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
                      repository.Delete(contact);
                      repository.Save();
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
                      var contact = repository.Get(Convert.ToInt32(tbx));
                      var number = "No contact found";
                      if (contact != null)
                      {
                          number = $"Result number is: {contact.Number}";
                      }

                      MessageBox.Show(number, "Find contact",
                          MessageBoxButton.OK, MessageBoxImage.Information);
                  }));
            }
        }
    }
}
