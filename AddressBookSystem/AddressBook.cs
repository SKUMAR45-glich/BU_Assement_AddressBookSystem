using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        string _name;                                                                               //private field
        public AddressBook()
        {
            this._name = "General";                                                              //Default Constructor
        }

        public AddressBook(string name)
        {
            this._name = name;                                                                   //Parameterize Constructor
        }

        public string Name { get => _name; set => _name = value; }                                    //Auto Get Set Method

    }
}
