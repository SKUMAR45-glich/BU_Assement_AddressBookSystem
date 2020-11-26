﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class ContactDetails
    {
        //Initailizaing Variables

        string _firstName;
        string _lastName;                                       
        Address _address;
        string _phNo;
        string _email;


        //Default Constructor
        public ContactDetails()
        {
            this._firstName = "";
            this._lastName = "";
            this._address = new Address();
            this._phNo = "";
            this._email = "";
        }


        //Parametrized Constructor
        public ContactDetails(string FirstName, string LastName, string City, string State, string Zip, string PhoneNumber, string Email)
        {
            this._firstName = FirstName;
            this._lastName = LastName;
            this._address = new Address(City, State, Zip);
            this._phNo = PhoneNumber;
            this._email = Email;
        }


        //Auto GetSet Properties
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string PhoneNumber { get => _phNo; set => _phNo = value; }
        public string Email { get => _email; set => _email = value; }
        public string City { get => _address.City; set => _address.City = value; }
        public string State { get => _address.State; set => _address.State = value; }
        public string Zip { get => _address.Zip; set => _address.Zip = value; }


        //Display the ContactDetails 
        public string Display()
        {
            return "\nName : " + this.FirstName + " " + this.LastName + "\nAddress : " + this.City + "," + this.State + "," + this.Zip +
                "\nPhone : " + this.PhoneNumber + "\nEmail Id : " + this.Email;
        }
    }
}
