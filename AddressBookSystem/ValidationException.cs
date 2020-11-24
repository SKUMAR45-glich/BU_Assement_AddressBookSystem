using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class ValidationException : Exception
    {
        public enum InvalidationType
        {
            INVALID_FIRST_NAME,
            INVALID_EMAIL,
            INVALID_PHONE_NUMBER
        }

        private readonly InvalidationType invalid;

        public ValidationException(InvalidationType type, string message) : base(message)
        {
            invalid = type;
        }
    }
}
