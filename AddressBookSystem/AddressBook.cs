using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

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

        //Function for FileInputOuput
        public void DoIO()
        {
            Console.Write("1. Save/Write as .txt file\n2. Read a .txt file\nEnter your option :");                        
            var input = Convert.ToInt32(Console.ReadLine());
            
            switch (input)
            {
            
                case 1:
                    var path = @"C:\Users\saura\BU_FilesforC#\" + _name + ".txt";                           //Make the path where to make the text file 
                   
                    using (var streamWriter = File.AppendText(path))                                             //Append the values in a text file
                    {
                        foreach (var contact in _AddressBookforImplement[_name].AddressBook)
                        {
                            streamWriter.WriteLine(contact.Value.FirstName + " " + contact.Value.LastName);
                        }
                        streamWriter.Close();
                    }
                    break;

                case 2:
                    path = @"C:\Users\saura\BU_FilesforC#\" + _name + ".txt";                                      
                    
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("No Such File Exists");
                        break;
                    }
                    
                    using (var streamReader = File.OpenText(path))
                    {
                        string str = "";
                        while ((str = streamReader.ReadLine()) != null)                                 //Read the data of Text file
                            Console.WriteLine(str);
                    }
                    break;

                default:
                    Console.WriteLine("Plaese Enter correct option");
                    break;
            }
        }

        //Implementation of CSV form
        public void ImplementCSVDataHandling()
        {
            Console.Write("1. Save/Write as .csv file\n2. Read a .csv file\nEnter your option :");
            int input = Convert.ToInt32(Console.ReadLine());
            
            switch (input)
            {
                case 1:
                    string path = @"C:\Users\saura\BU_FilesforC#\" + _name + ".csv";                         //Write File in CSV form
                    using (var writer = new StreamWriter(path))
                    using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        var list = _AddressBookforImplement[_name].AddressBook;
                        csvWriter.WriteRecords(list);
                    }
                    break;
                
                case 2:
                    path = @"C:\Users\saura\BU_FilesforC#\" + _name + ".csv";                                    
                    
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("No Such File Exists, Please Save before reading.");
                        break;
                    
                    }
                    
                    using (var reader = new StreamReader(path))
                    using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))                          //Read the entered details
                    {
                        var contacts = csvReader.GetRecords<ContactDetails>().ToList();
                        Console.WriteLine("There are following contacts saved in file : ");
                        foreach (var contact in contacts)
                        {

                            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Please Enter correct Value");
                    break;
            }
        }

        //Implement in JSON form
        public void ImplementJSONDataHandling()
        {
            Console.Write("1. Save/Write as .json file\n2. Read a .json file\nEnter your option :");
            int input = Convert.ToInt32(Console.ReadLine());
            
            switch (input)
            {
                case 1:
                    string path = @"C:\Users\saura\BU_FilesforC#\" + _name + ".json";
                    var list = _AddressBookforImplement[_name].AddressBook.ToList();
                    var copy = new List<ContactDetails>();
                    foreach (var item in list)
                        copy.Add(item.Value);
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    using (var streamWriter = new StreamWriter(path))
                    using (var jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        serializer.Serialize(jsonWriter, copy);
                    }
                    break;
                case 2:
                    path = @"C:\Users\saura\BU_FilesforC#\" + _name + ".json";
                    var contacts = JsonConvert.DeserializeObject<List<KeyValuePair<string, ContactDetails>>>(File.ReadAllText(path));
                    foreach (var contact in contacts)
                    {
                        Console.WriteLine($"{contact.Value.FirstName} {contact.Value.LastName}");
                    }
                    break;

                default:
                    Console.WriteLine("Please Enter correct Value");
                    break;
            }
        }
    }
}
