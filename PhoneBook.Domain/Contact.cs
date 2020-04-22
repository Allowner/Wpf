using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Contact : IDataErrorInfo, INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private string _email;
        private long? _number;
        public int Id { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }


        public string Surname
        {
            get { return _surname; }
            set { _surname = value; NotifyPropertyChanged("Surname"); }
        }


        public long? Number
        {
            get { return _number; }
            set { _number = value; NotifyPropertyChanged("Number"); }
        }


        public string Email
        {
            get { return _email; }
            set { _email = value; NotifyPropertyChanged("Email"); }
        }


        public string Error => "Error occured";

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (Name == null || Name.Length == 0 || Name.Length > 30)
                        {
                            error = "Name should be in the range from 1 to 30";
                        }

                        break;
                    case "Surname":
                        if (Surname == null || Surname.Length == 0 || Surname.Length > 30)
                        {
                            error = "Surname should be in the range from 1 to 30";
                        }

                        break;
                    case "Number":
                        if (Number == null)
                        {
                            error = "Number can not be empty";
                        }

                        break;
                    case "Email":
                        if (Email == null || !Email.Contains("@") || Email.Length < 5)
                        {
                            error = "Not valid email";
                        }

                        break;
                }

                return error;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayMember"));
            }
        }
    }
}
