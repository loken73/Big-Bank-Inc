using System;

namespace Big_Bank_Inc
{
    public static class Menu 
    {
        private static string input;

        public static string [] mainOptionsMenu = new string [] 
        {
            "- Create New User",
            "- Create New Account",
            "- Manage Accounts",
            "- Quit"
        };

        public static string [] createAccountOptionsMenu = new string []
        {
            "- Create a New Checking Account",
            "- Create a New Savings Account",
        };

        public static string[] manageAccountOptionsMenu = new string []
        {
            "- Manage an Existing Account",
            "- Check Balances"
        };

        public static string [] individualAccountOptions = new string []
        {
            "- Deposit to selected Account",
            "- Withdraw from selected account"
        };

        public static void MenuWriter (string[] menuArray)
        {
            for(int i = 0; i <= menuArray.Length - 1; i++)
            {
                var optionNumber = i+1;

                Console.WriteLine("{0} {1}", optionNumber, menuArray[i]);
            }
        }

        public static string PromptFirstName ()
        {
            System.Console.WriteLine("Please provide your first name.");
            input = Console.ReadLine();
            return input;
        }

        public static string PromptLastName()
        {
            System.Console.WriteLine("Please provide your first name.");
            input = Console.ReadLine();
            return input;
        }

        public static string PromptSSN ()
        {
            System.Console.WriteLine("Please provide your social security number.");
            input = Console.ReadLine();
            return input;
        }

        public static void OpenAccountDisplayByType(Account generatedAccount)
        {
            Console.WriteLine($"How much would you like to add to open account { generatedAccount.AccountNumber }.");
            System.Console.WriteLine();
        }

    }

}
