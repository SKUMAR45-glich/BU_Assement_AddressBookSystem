using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        string _name;
        public AddressBook()
        {
            this._name = "General";
        }

        public AddressBook(string name)
        {
            this._name = name;
        }

        public string Name { get => _name; set => _name = value; }

    }
}
