using System;

namespace AddressBookSystem
{
    public class Program                                                                          
    {

        //Main Method

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");                                      //Welcome Message
            Console.WriteLine("========================");

            AddressBook addressBook = new AddressBook();
            addressBook.Name = "General";                                                     // Default value of AddressBook

            bool checkAddressBook = true;                                                     //For initializing the AddressBook
            bool checkContactDetails = true; ;                                                //For initializing the contact Details in AddressBook


            //AddressBook

            while (checkAddressBook)
            {
                Console.WriteLine("Enter\n" +
                "1 : To Add a new Address Book\n" +                                              
                "2 : To use current address books ( " + addressBook.Name + " )\n" +
                "3 : Switch Address Book\n" +
                "0 : Exit");

                int userChoice;

                try
                {
                    userChoice = Int32.Parse(Console.ReadLine());                                  //Exception to ensure only Numbers are entered
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    userChoice = 0;
                }
                 


                switch (userChoice)
                {

                    case 1:
                        checkContactDetails = true;
                        Console.WriteLine("Add Name of the new Address Book");                       //Creating the AddressBook
                        addressBook.Name = Console.ReadLine();

                        break;


                    case 2:
                        checkContactDetails = true;

                        break;


                    case 3:
                        checkContactDetails = true;
                        Console.WriteLine("Enter Name of the Address Book you want to switch");             //Switch the AddressBook
                        addressBook.Name = Console.ReadLine();

                        break;


                    case 0:
                        checkAddressBook = false;
                        checkContactDetails = false;                                                    //Exit the AddressBookSystem
                        break;

                    default:
                        Console.WriteLine("Wrong Option Entered");
                        break;
                }



                while (checkContactDetails)
                {
                    int choice;

                    Console.WriteLine("You are in " + addressBook.Name);                //Name of AddressBook


                    Console.WriteLine("Enter\n" +
                    "1 : Add Contact Details to " + addressBook.Name + " Address Book\n" +
                    "2 : Edit a Contact Detail\n" +
                    "3 : Delete a Contact Detail\n" +
                    "4: Display the contents of the AddresBook"+
                    "0 : Exit");

                    try
                    {
                        choice = Int32.Parse(Console.ReadLine());                           
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);                
                        choice = 0;
                    }

                    switch (choice)
                    {
                        case 1:
                            addressBook.AddNewContactToAddressBook();                      //Function to add Contact in AddressBook
                            break;

                        case 4:
                            addressBook.DisplayContactsInCurrentAddressBook();               //Display the Contact in the AddressBook
                            break;

                        case 0:
                            checkContactDetails = false;                              //Exist the present AddressBook
                            break;

                        default:
                            Console.WriteLine("Please Enter Correct Oprtion");
                            break;
                    }
                }
            }
        }
    }
}
