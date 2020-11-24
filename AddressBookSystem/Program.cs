using System;

namespace AddressBookSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
            Console.WriteLine("========================");

            AddressBook addressBook = new AddressBook();
            addressBook.Name = "General";

            bool checkAddressBook = true;
            bool checkContactDetails = true; ;


            while (checkAddressBook)
            {
                Console.WriteLine("Enter\n" +
                "1 : To Add a new Address Book\n" +
                "2 : To use current address books ( " + addressBook.Name + " )\n" +
                "3 : Switch Address Book\n" +
                "0 : Exit");

                int userChoice = Int32.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        checkContactDetails = true;
                        Console.WriteLine("Add Name of the new Address Book");
                        addressBook.Name = Console.ReadLine();
                        break;
                    case 2:
                        checkContactDetails = true;
                        break;
                    case 3:
                        checkContactDetails = true;
                        Console.WriteLine("Enter Name of the Address Book you want to switch");
                        addressBook.Name = Console.ReadLine();
                        break;
                    case 0:
                        checkAddressBook = false;
                        checkContactDetails = false;
                        break;
                    default:
                        Console.WriteLine("Wrong Option Entered");
                        break;
                }

                while (checkContactDetails)
                {
                    Console.WriteLine("You are in " + addressBook.Name);
                    checkContactDetails = false;

                }
            }
        }
    }
}
