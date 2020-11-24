using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookSystem
{
    public class AddressBookImplementation
    {
        Dictionary<string, ContactDetails> _addressBook;


        //Regex Checking for Values

        Regex regexName = new Regex(@"[A-Z][a-z]{2,}$");
        Regex regexEmail = new Regex(@"[A-Za-z]{1,}([.][A-Za-z]{1,}){0,1}[@][A-Za-z]{1,}[.][A-Za-z]{2,}([.][A-Za-z]{2,3}){0,1}$");
        Regex regexPhone = new Regex(@"[91][ ]{0,1}[0-9]{10}$");


        //Default Constructor

        public AddressBookImplementation()
        {
            this._addressBook = new Dictionary<string, ContactDetails>();
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

            _addressBook.Add(contact.FirstName, contact);


            return;
        }


        //Display Contact Details
        public void DisplayAllContacts()
        {
            Console.WriteLine("All Contacts are :");
            foreach(var item in _addressBook)
            {
                Console.WriteLine(item.Value.Display());
            }
        }
    }
}
