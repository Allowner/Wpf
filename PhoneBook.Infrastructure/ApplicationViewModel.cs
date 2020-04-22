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
        private readonly Func<Contact, Contact> windowDelegate;
        private readonly Action<string, string> messageDelegate;

        private Command addCommand, editCommand, deleteCommand, findCommand;

        public IEnumerable<Contact> Contacts
        {
            get;
            set;
        }

        public ApplicationViewModel(IRepository<Contact> repository, Func<Contact, Contact> windowDelegate,
            Action<string, string> messageDelegate)
        {
            this.repository = repository;
            this.windowDelegate = windowDelegate;
            this.messageDelegate = messageDelegate;
            Contacts = repository.GetList();
        }

        public Command AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new Command((o) =>
                  {
                      var contact = windowDelegate.Invoke(new Contact());
                      if (contact != null)
                      {
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

                      var newContact = windowDelegate.Invoke(vm);
                      if (newContact != null)
                      {
                          contact = repository.Get(newContact.Id);
                          if (contact != null)
                          {
                              contact.Name = newContact.Name;
                              contact.Surname = newContact.Surname;
                              contact.Number = newContact.Number;
                              contact.Email = newContact.Email;
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

                      messageDelegate("Find contact", number);
                  }));
            }
        }
    }
}
