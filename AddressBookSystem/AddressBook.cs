﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
            logDetails.LogInfo("Data Displayed");
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


        //Sorting 
        public void SortPersonsByName()
        {
            if (_AddressBookforImplement.ContainsKey(_name))                                                           //Check for AddressBook Name
            {
                List<string> sortedPersonsByName = _AddressBookforImplement[_name].sortedByName();                          //Function to sort by name
                if (sortedPersonsByName.Count > 0)
                {
                    Console.WriteLine("Contacts after sorting by name");
                    foreach (string person in sortedPersonsByName)
                        Console.WriteLine(person);                                                                     //Display
                }
            }
            else
            {
                Console.WriteLine("Please Enter Correct AddressBook");
            }
        }

        public void DoIO()
        {
            Console.Write("1. Save/Write as .txt file\n2. Read a .txt file\nEnter your option :");
            var input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    WriteUsingStreamWriter();
                    break;
                
                case 2:
                    ReadfromStreamReader();
                    break;
            }

            
        }

        public static void ReadfromStreamReader()
        {
            string path = @"C:/Users/saura/Desktop/Training/BU_Presentation/AddressBookusingC#/AddressBookSystem/Example.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        public static void WriteUsingStreamWriter()
        {
            string path = @"C:/Users/saura/Desktop/Training/BU_Presentation/AddressBookusingC#/AddressBookSystem/Example.txt";
            using (StreamWriter sr = File.AppendText(path))
            {
                sr.WriteLine("Hello World - .Net is Awesome");
                sr.Close();

                Console.WriteLine(File.ReadAllText(path));
            }
        }


        public void ImplementCSVDataHandling()
        {
            string supportFilePath = @"C:\Users\saura\Desktop\Training\BU_Presentation\AddressBookusingC#\AddressBookSystem\addressBook.csv";
            string exportFilePath = @"C:\Users\saura\Desktop\Training\BU_Presentation\AddressBookusingC#\AddressBookSystem\exportaddressBook.csv";
            using (var reader = new StreamReader(supportFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ContactDetails>().ToList();
                Console.WriteLine("Data Reading Done Succrssfully ");
                foreach (ContactDetails addressData in records)
                {
                    Console.WriteLine("\t" + addressData.FirstName);
                    Console.WriteLine("\t" + addressData.LastName);
                    Console.WriteLine("\t" + addressData.City);
                    Console.WriteLine("\t" + addressData.PhoneNumber);
                    Console.WriteLine("\t" + addressData.State);
                    Console.WriteLine("\t" + addressData.Zip);
                    Console.WriteLine("\n");

                }
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }

            }
        }

    }
}
