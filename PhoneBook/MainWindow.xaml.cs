using PhoneBook.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Func<Contact, Contact> showContactWindow = (contact) => GetNewContact(contact);
        Action<string, string> showFindWindow = (title, message) => MessageBox.Show(message, title,
                          MessageBoxButton.OK, MessageBoxImage.Information);
        public MainWindow(IRepository<Contact> repository)
        {
            InitializeComponent();
            this.DataContext = new ApplicationViewModel(repository, showContactWindow, showFindWindow);
        }

        private static Contact GetNewContact (Contact contact)
        {
            var window = new ContactWindow(contact);
            if (window.ShowDialog() == true)
            {
                return window.Contact;
            }
            else
            {
                return null;
            }
        }
    }
}
