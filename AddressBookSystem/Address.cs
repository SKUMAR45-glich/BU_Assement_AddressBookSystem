﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class Address
    {
        string _city;
        string _state;
        string _zip;

        public Address()
        {
            this.City = "";
            this.State = "";
            this.Zip = "";
        }

        public Address(string City, string State, string Zip)
        {
            this.City = City;
            this.State = State;
            this.Zip = Zip;
        }

        public string City { get => _city; set => _city = value; }
        public string State { get => _state; set => _state = value; }
        public string Zip { get => _zip; set => _zip = value; }
    }
}
