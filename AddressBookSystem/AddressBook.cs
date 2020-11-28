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


        //Display Contact Details By Accoring to State in full AddressBook
        public void SearchinAddressBooksByState()
        {
            Console.WriteLine("Enter the State to be searched:");
            string state = Console.ReadLine();

            foreach (var addressBook in _AddressBookforImplement)
            {
                addressBook.Value.DisplayContactByState(state);                                  //Search by State
            }
        }

        //Display Contact Details By Accoring to City in full AddressBook
        public void SearchinAddressBooksByCity()
        {
            Console.WriteLine("Enter the City to be searched:");
            string city = Console.ReadLine();

            foreach (var addressBook in _AddressBookforImplement)
            {
                addressBook.Value.DisplayContactByCity(city);                                     //Search by State
            }
        }


        //Dictionary with key as State
        public Dictionary<string, int> CountPersonsByState()
        {
            Dictionary<string, int> count = new Dictionary<string, int>();

            Dictionary<string, List<string>> personsByState = new Dictionary<string, List<string>>();
            personsByState = SearchPersonsByState();
            foreach (var items in personsByState)
            {
                count.Add(items.Key, items.Value.Count);
            }

            return count;
        }

        //Display the State and Count
        public void DisplayPersonCountByState()
        {
            Dictionary<string, int> countByState = new Dictionary<string, int>();
            countByState = CountPersonsByState();

            Console.WriteLine("State     Count");
            Console.WriteLine("_________________");
            foreach (var item in countByState)
            {
                Console.WriteLine(item.Key + "     " + item.Value);
            }
            Console.WriteLine();
        }

        //Dictionary to search Value
        private Dictionary<string, List<string>> SearchPersonsByState()
        {
            Dictionary<string, List<string>> detailsOfAllByState = new Dictionary<string, List<string>>();
            foreach (var addressBook in _AddressBookforImplement)
            {
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                dict = addressBook.Value.AllContactNamesByState();
                foreach (var item in dict)
                {
                    if (detailsOfAllByState.ContainsKey(item.Key))
                        detailsOfAllByState[item.Key].AddRange(item.Value);
                    else
                        detailsOfAllByState.Add(item.Key, item.Value);
                }
            }
            return detailsOfAllByState;
        }


        //Dictionary for counting the city
        public Dictionary<string, int> CountPersonsByCity()
        {
            Dictionary<string, int> count = new Dictionary<string, int>();

            Dictionary<string, List<string>> personsByCity = new Dictionary<string, List<string>>();
            personsByCity = SearchPersonsByCity();
            foreach (var items in personsByCity)
            {
                count.Add(items.Key, items.Value.Count);
            }

            return count;
        }


        //Function to diplay the city and count
        public void DisplayPersonCountByCity()
        {
            Dictionary<string, int> countByCity = new Dictionary<string, int>();
            countByCity = CountPersonsByCity();

            Console.WriteLine("City     Count");
            Console.WriteLine("_________________");
            foreach (var item in countByCity)
            {
                Console.WriteLine(item.Key + "     " + item.Value);
            }
        }


        //Search for the city as per user choice of city
        private Dictionary<string, List<string>> SearchPersonsByCity()
        {
            Dictionary<string, List<string>> detailsOfAllByCity = new Dictionary<string, List<string>>();
            foreach (var addressBook in _AddressBookforImplement)
            {
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                dict = addressBook.Value.AllContactNamesByCity();
                foreach (var item in dict)
                {
                    if (detailsOfAllByCity.ContainsKey(item.Key))
                        detailsOfAllByCity[item.Key].AddRange(item.Value);
                    else
                        detailsOfAllByCity.Add(item.Key, item.Value);
                }
            }
            return detailsOfAllByCity;
        }
    }
}
