using System;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookSystem
{
    public class AddressBookImplementation
    {
        public Dictionary<string, ContactDetails> AddressBook = new Dictionary<string, ContactDetails>();
        public Dictionary<string, List<string>> _personByState = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> _personByCity = new Dictionary<string, List<string>>();

        LogDetails logDetails = new LogDetails();


        //Regex Checking for Values

        Regex regexName = new Regex(@"[A-Z][a-z]{2,}$");
        Regex regexEmail = new Regex(@"[A-Za-z]{1,}([.][A-Za-z]{1,}){0,1}[@][A-Za-z]{1,}[.][A-Za-z]{2,}([.][A-Za-z]{2,3}){0,1}$");
        Regex regexPhone = new Regex(@"[91][ ]{0,1}[0-9]{10}$");


        //Default Constructor

        public AddressBookImplementation()
        {
            //this.AddressBook = new Dictionary<string, ContactDetails>();
        }


        //Add Contact Details to the Address Book
        public void AddContactDetails()
        {
            ContactDetails contact = new ContactDetails();

            Console.WriteLine("Enter\n");

            Console.Write("First Name : ");
            contact.FirstName = Console.ReadLine();

            //Throw Exception if Name is InValid
            if (!regexName.IsMatch(contact.FirstName))
            {
                throw new ValidationException(ValidationException.InvalidationType.INVALID_FIRST_NAME, "Please enter first letter capital and length morethan equal to 3");
            }
            Console.Write("Last Name : ");
            contact.LastName = Console.ReadLine();
            Console.Write("City : ");
            contact.City = Console.ReadLine();
            Console.Write("State : ");
            contact.State = Console.ReadLine();
            Console.Write("Zip : ");
            contact.Zip = Console.ReadLine();
            Console.Write("Phone Number : ");
            contact.PhoneNumber = Console.ReadLine();

            //Throw Exception if PhoneNumber is InValid
            if (!regexPhone.IsMatch(contact.PhoneNumber))
            {
                throw new ValidationException(ValidationException.InvalidationType.INVALID_PHONE_NUMBER, "Phone Number should start with 91 and have exactly 10 digits");
            }


            Console.Write("Email : ");
            contact.Email = Console.ReadLine();

            //Throw Exception if Email is InValid
            if (!regexEmail.IsMatch(contact.Email))
            {
                throw new ValidationException(ValidationException.InvalidationType.INVALID_EMAIL, "Please Enter Valid Email ID");
            }
            Console.WriteLine();

            AddressBook.Add(contact.FirstName, contact);                 //Addition in Dictionary with FirstName as Key

            AddToStateDict(contact.State, contact.FirstName);
            AddToCityDict(contact.City, contact.FirstName);


            return;
        }


        //Edit the Details

        public void EditContactDetails()
        {
            string name;
            Console.WriteLine("Enter First Name whose details need to be edited ");
            name = Console.ReadLine();

            if (AddressBook.ContainsKey(name))
            {


                bool notCompleted = true;
                int choice;

                Console.WriteLine("Enter\n" +
                        "1 : Edit City\n" +
                        "2 : Edit State\n" +
                        "3 : Edit Zip\n" +
                        "4 : Edit Phone Number\n" +
                        "5 : Edit Email ID\n" +
                        "0 : Edit Completed");

                while (notCompleted)
                {
                    try
                    {
                        choice = Int32.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        logDetails.LogDebug("Class : AddressBookMain , Method : EditContact, Field : choice");
                        logDetails.LogError(e.Message + " It should be a integer");
                        choice = 0;
                    }
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Edit Updated City :");
                            AddressBook[name].City = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Edit Updated State :");
                            AddressBook[name].State = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Edit Updated Zip :");
                            AddressBook[name].Zip = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("Edit Updated Phone Number :");
                            AddressBook[name].PhoneNumber = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("Edit Updated Email Id :");
                            AddressBook[name].Email = Console.ReadLine();
                            break;
                        case 0:
                            notCompleted = false;
                            break;
                        default:
                            Console.WriteLine("Wrong Choice\nChoose Again");
                            break;
                    }
                    if (choice != 0)
                        Console.WriteLine("\nIf there is anything else to edit, enter respective number\n" + "else enter 0 to exit");
                }

            }
        }

        //Delete the Contact Details
        public void DeleteContactDetails()
        {
            string name;
            Console.WriteLine("Enter First Name whose details need to be deleted ");
            name = Console.ReadLine();

            if (AddressBook.ContainsKey(name))
            {
                AddressBook.Remove(name);
                Console.WriteLine("Details of " + name + " deleted successfully");
            }
            else
                Console.WriteLine("Details of " + name + " is not present");
            return;
        }


        //Display Contact Details
        public void DisplayAllContacts()
        {
            Console.WriteLine("All Contacts are :");
            foreach (var item in AddressBook)
            {
                Console.WriteLine(item.Value.Display());
            }
        }


        //Display Contact Details By Accoring to State
        public void DisplayContactByState(string state)
        {
            foreach (var item in AddressBook)
            {
                if (item.Value.State == state)                                            //Check for the State
                    Console.WriteLine(item.Value.Display());
            }
        }


        //Display Contact Details By Accoring to City
        public void DisplayContactByCity(string city)
        {
           foreach (var item in AddressBook)
            {
                if (item.Value.City == city)                                             //Check for the City
                    Console.WriteLine(item.Value.Display());
            }
        }


        private void AddToStateDict(string state, string name)
        {
            if (this._personByState.ContainsKey(state))
                this._personByState[state].Add(name);
            else
                this._personByState.Add(state, new List<string>() { name });
        }


        private void AddToCityDict(string city, string name)
        {
            if (this._personByCity.ContainsKey(city))
                this._personByCity[city].Add(name);
            else
                this._personByCity.Add(city, new List<string>() { name });
        }


        public Dictionary<string, List<string>> AllContactNamesByState()
        {
            return _personByState;
        }


        public Dictionary<string, List<string>> AllContactNamesByCity()
        {
            return _personByCity;
        }

        //Sorted by Name
        public List<string> sortedByName()
        {
            List<string> sortedName = new List<string>();
            foreach (var element in AddressBook)
            {
                sortedName.Add(element.Value.Display());
            }
            sortedName.Sort();
            return sortedName;
        }

    }
}
