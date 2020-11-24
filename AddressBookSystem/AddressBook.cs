﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        LogDetails logDetails = new LogDetails();


        //Dictionary for AddressbookImplementation with Key as AddressBook name and vale as Implementation Function

        Dictionary<string, AddressBookImplementation> _AddressBookforImplement = new Dictionary<string, AddressBookImplementation>();



        string _name;
        public AddressBook()                                                           //Intialize a Constructor
        {
            this._name = "General";
        }

        public AddressBook(string name)                                                   //Initailize a Parametrize Constructor
        {
            this._name = name;
        }

        public string Name { get => _name; set => _name = value; }                      //Auto GetSet Properties


        //Function to Add Details
        public void AddNewContactToAddressBook()
        {

            if (_AddressBookforImplement.ContainsKey(this._name))                       //If Contact Details is to inserted in the same AddresBook
                _AddressBookforImplement[this._name].AddContactDetails();
            else
            {

                AddressBookImplementation addressBookImplementation = new AddressBookImplementation();           //Entering details in a new AddressBook
                addressBookImplementation.AddContactDetails();
                _AddressBookforImplement.Add(this._name, addressBookImplementation);
            }

            logDetails.LogInfo("Added Succesfully");


        }

        //Display contact details in current address book
        public void DisplayContactsInCurrentAddressBook()
        {
            _AddressBookforImplement[Name].DisplayAllContacts();
            logDetails.LogInfo("Data Dispaced");
        }

    }
}