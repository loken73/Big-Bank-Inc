using System;
using System.Collections.Generic;
using System.Text;

namespace Big_Bank_Inc
{
    public static class Validator
    {
        private static bool IsInputGivenNumeric(string userInput)
        {
            bool intInString = Int32.TryParse(userInput, out int result);

            return intInString;
        }

        public static string ValidateNameGiven(string guide)
        {
            var inputName = "";
            bool isNumber;

            do
            {
                if (guide == "fn")
                {
                    inputName = Menu.PromptFirstName();
                }
                else if (guide == "ln")
                {
                    inputName = Menu.PromptLastName();
                }
                
                isNumber = IsInputGivenNumeric(inputName);
                Console.WriteLine();

            } while (inputName.Length < 2 || isNumber == true);

            return inputName;
        }

        public static string ValidateUserSsn()
        {
            var ssn = "";
            var isNumber = false;

            do
            {
                ssn = Menu.PromptSSN();
                isNumber = IsInputGivenNumeric(ssn);
                Console.WriteLine();

            } while (ssn.Length < 9 || isNumber == false);

            return ssn;
        }

        public static decimal IsInitialInvestmentDecimal()
        {
            var enteredAmount = Console.ReadLine();
            decimal openingAmount;
            bool amountIsInt;

            do
            {

                amountIsInt = Decimal.TryParse(enteredAmount, out openingAmount);

            } while (amountIsInt == false);

            return openingAmount;
        }
    }
}
