using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Contact : IDataErrorInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public long? Number { get; set; }

        public string Email { get; set; }

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
                        if (Number == null || Number.ToString().Length != 7)
                        {
                            error = "Number should be 7 numbers long";
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
    }
}
