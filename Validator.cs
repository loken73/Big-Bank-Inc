using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Bank_Inc
{
    public static class Validator
    {
        public  static string ValidateUserFirstName()
        {
            var firstName = "";
            bool isNumber;

            do
            {
                System.Console.WriteLine("Please provide your first name.");
                firstName = Console.ReadLine();
                isNumber = IsInputGivenNumeric(firstName);
                System.Console.WriteLine();

            } while (firstName.Length < 2 || isNumber == true);

            return firstName;
        }
    }
}
