using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        

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



        }

        //Edit the Contact Details
        public void EditDetailsInAddressBook()
        {

            _AddressBookforImplement[Name].EditContactDetails();                            //Editing by AddressBook Name as key
        }


        //Delete a contact detail
        public void DeletetheContactDetail()
        {
            _AddressBookforImplement[Name].DeleteContactDetails();                         //Deleting by AddressBook Name as key
        }


        //Display contact details in current address book
        public void DisplayContactsInCurrentAddressBook()
        {
            _AddressBookforImplement[Name].DisplayAllContacts();                         //Display by AddressBook Name as key
            
        }


        //Search by State and City
        public void SearchByState()
        {
            Console.WriteLine("Enter the State to be searched:");
            string state = Console.ReadLine();

            _AddressBookforImplement[Name].DisplayContactByState(state);                      //Search by State by AddressBook Name as key
        }

        public void SearchByCity()
        {
            Console.WriteLine("Enter the City to be searched:");
            string city = Console.ReadLine();

            _AddressBookforImplement[Name].DisplayContactByCity(city);                      //Search by city by AddressBook Name as key
        }

    }
}
