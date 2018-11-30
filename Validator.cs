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
                if (guide == "1")
                {
                    inputName = Menu.PromptFirstName();
                }
                inputName = Menu.PromptFirstName();
                isNumber = IsInputGivenNumeric(inputName);
                Console.WriteLine();

            } while (inputName.Length < 2 || isNumber == true);

            return inputName;
        }
    }
}
