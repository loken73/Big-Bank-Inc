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

        public static void DisplayInitialAccountInvestment(Account generatedAccount)
        {
            Console.WriteLine();

            System.Console.WriteLine($"You added ${ generatedAccount.AccountAmountCurrent } to your savings account { generatedAccount.AccountNumber }.");

            System.Console.WriteLine();
        }

        public static void AccountsMenuHeader()
        {
            System.Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("List of Current Accounts");

            Console.ResetColor();
            System.Console.WriteLine("--------------------------");
        }

        public static string LastFourAccountDigits()
        {
            System.Console.WriteLine();

            System.Console.WriteLine("Which account above would you like to modify? Please enter the last 4 digits of the account number.");

            return Console.ReadLine();
        }

        public static void ManageAllAccountsUserHeader(User currentUser)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine();

            System.Console.WriteLine($"Account Holder: { currentUser.FullName }");
            Console.ResetColor();
            System.Console.WriteLine("-----------------------------------");

            Console.WriteLine();
        }

        public static void ManageAccountsCheckingAccountListHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Checking Accounts");

            Console.ResetColor();
            System.Console.WriteLine("-----------------");
        }

        public static void ManageAccountsSavingsAccountListHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Savings Accounts");

            Console.ResetColor();
            System.Console.WriteLine("-----------------");
        }

        public static void TotalInAllAccounts(decimal totalInAllAccounts)
        {
            Console.WriteLine();

            Console.WriteLine($"Total Amount of funds deposited currently in bank is ${ totalInAllAccounts }");

            Console.WriteLine();
        }

        public static void MainMenuWriter(string mainOption)
        {
            Console.ResetColor();

            Console.WriteLine();

            MenuWriter(mainOptionsMenu);

            mainOption = Console.ReadLine();

            Console.WriteLine();
        }

        public static void ListOfCheckingAccounts(User currentUser, decimal totalInAllAccounts)
        {
            foreach (Account act in currentUser.Accounts)
            {
                if (act as CheckingAccount != null)
                {
                    Console.WriteLine($"{act.AccountNumber} : ${act.AccountAmountCurrent}");
                    totalInAllAccounts += act.AccountAmountCurrent;
                }
            }
        }

        public static void AccountsMenuListOfAccounts(User currentUser)
        {
            var accountListOption = 1;

            foreach (Account act in currentUser.Accounts)
            {

                if (act as CheckingAccount != null)
                {
                    Console.WriteLine("{0} - Checking: {1}", accountListOption, act.AccountNumber);

                }

                if (act as SavingsAccount != null)
                {
                    Console.WriteLine("{0} - Savings: {1}", accountListOption, act.AccountNumber);

                }

                accountListOption++;
            }
        }
    }

}
