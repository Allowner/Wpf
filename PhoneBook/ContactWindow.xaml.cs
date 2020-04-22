using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для ContactWindow.xaml
    /// </summary>
    public partial class ContactWindow : Window
    {
        public Contact Contact { get; private set; }

        public ContactWindow(Contact contact)
        {
            InitializeComponent();
            Contact = contact;
            this.DataContext = Contact;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
