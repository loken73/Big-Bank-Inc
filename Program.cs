using System;
using System.Collections.Generic;

namespace Big_Bank_Inc
{
    class Program
    {

        private static string mainOption = "";

        private static User currentUser = null;

        private static Menu fullMenu = new Menu();

        private static decimal totalInAllAccounts;

        static void Main(string[] args)
        {
            do 
            {
                MainMenuWriter();
               
                //Create User Option
                if (mainOption == "1")
                {
                    string firstName = ValidateUserFirstName();

                    string lastName = ValidateUserLastName();

                    string socialSecurityNumber = ValidateUserSsn();

                    currentUser = CreateUser(firstName, lastName, socialSecurityNumber);              
                }
                //Create Account Option
                if (mainOption == "2")
                {
                    var createAccountOption = "";

                    //If current user does not exist
                    if (currentUser == null)
                    {
                        Console.WriteLine("Please choose option 1 from the Main Menu and create a new customer account.\n");
                    }
                    //Else if current user exists
                    else 
                    {
                        fullMenu.MenuWriter(fullMenu.createAccountOptionsMenu);
                        createAccountOption = Console.ReadLine();

                        System.Console.WriteLine();

                        //Create Checking Account Option
                        if (createAccountOption == "1")
                        {
                            Account checkingAccount = CreateAccountByType(createAccountOption);

                            OpenAccountDisplayByType(checkingAccount);

                            decimal openingAmount = IsInitialInvestmentDecimal();

                            checkingAccount.InitialInvestment(openingAmount, new DateTime(2015, 01, 01));

                            DisplayInitialAccountInvestment(checkingAccount);
                        }

                        //Create Savings Account 
                        if (createAccountOption == "2")
                        {

                            Account savingsAccount = CreateAccountByType(createAccountOption);

                            OpenAccountDisplayByType(savingsAccount);

                            decimal openingAmount = IsInitialInvestmentDecimal();

                            savingsAccount.InitialInvestment(openingAmount, new DateTime(2015, 01, 01));

                            DisplayInitialAccountInvestment(savingsAccount);

                        }
                    }
                }
                //Manage Accounts Option
                if (mainOption == "3")
                {
                    var manageAccountChoice = "";

                    fullMenu.MenuWriter(fullMenu.manageAccountOptionsMenu);

                    manageAccountChoice = Console.ReadLine();

                    System.Console.WriteLine();

                    //Manage an Individual Checking or Savings Account Option
                    if (manageAccountChoice == "1")
                    {
                        AccountsMenuHeader();

                        AccountsMenuListOfAccounts();

                        string accountLastFourDigits = LastFourAccountDigits();

                        Account selectedAccount = FindAccountByLastFourDigits(accountLastFourDigits);

                        if (selectedAccount != null)
                        {
                            ListAsCheckingOrSavings(selectedAccount);

                            fullMenu.MenuWriter(fullMenu.individualAccountOptions);

                            string withdrawOrDepositChoice = Console.ReadLine();

                            //Deposit Option for Individual Account
                            if (withdrawOrDepositChoice == "1")
                            {
                                DepositToSelectedAccount(selectedAccount);
                            }

                            //Withdraw Option for Individual Account
                            if (withdrawOrDepositChoice == "2")
                            { 
                                SubtractFromAccountSelected(selectedAccount);                            
                            }
                        }
                    }

                    //Check Balances of all accounts
                    if (manageAccountChoice == "2")
                    {
                        //Header of all accounts with current users name displayed
                        ManageAllAccountsUserHeader();

                        //Bools to check if either a savings or checking account exist in the current users list of accounts
                        var checkingIsInList = currentUser.Accounts.Exists(act => act as CheckingAccount != null);
                        var savingsIsInList = currentUser.Accounts.Exists(act => act as SavingsAccount != null);

                        if (checkingIsInList)
                        {                           
                            ManageAccountsCheckingAccountListHeader();

                            ListOfCheckingAccounts();
                        }

                        System.Console.WriteLine();

                        if (savingsIsInList)
                        {
                            ManageAccountsSavingsAccountListHeader();

                            ListOfSavingsAccounts();

                        }

                        TotalInAllAccounts();
                    }
                }

            //Main Menu Option 4 is to Quit Program
            } while (mainOption != "4");
        }


        /*                       Private Static Functions for Refactoring
        ======================================================================================================
         */



        private static User CreateUser(string firstName, string lastName, string socialSecurityNumber)
        {
            return new User(firstName, lastName, socialSecurityNumber);
        }

        private static string ValidateUserFirstName()
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

        private static string ValidateUserLastName()
        {
            var lastName = "";
            bool isNumber;

            do
            {
                System.Console.WriteLine("Please provide your last name.");
                lastName = Console.ReadLine();
                isNumber = IsInputGivenNumeric(lastName);
                System.Console.WriteLine();

            } while (lastName.Length < 2 || isNumber == true);

            return lastName;
        }

        private static string ValidateUserSsn()
        {
            var ssn = "";
            var isNumber = false;

            do
            {
                System.Console.WriteLine("Please provide your social security number.");
                ssn = Console.ReadLine();
                isNumber = IsInputGivenNumeric(ssn);
                System.Console.WriteLine();

            } while (ssn.Length < 9 || isNumber == false);

            return ssn;
        }

        private static bool IsInputGivenNumeric (string userInput)
        {
            bool intInString = Int32.TryParse(userInput, out int result);

            return intInString;
        }

        private static Account CreateAccountByType (string createAccountChoice)
        {
            Account accountToGenerate = null;

            if (createAccountChoice == "1")
            {
                accountToGenerate = new CheckingAccount(currentUser);
            }
            if (createAccountChoice == "2")
            {
                accountToGenerate = new SavingsAccount(currentUser);
            }

            currentUser.Accounts.Add(accountToGenerate);

            return accountToGenerate;
            //DisplayNewAccountNumberByType(accountToGenerate);
        }

        private static void DisplayNewAccountNumberByType (Account generatedAccount)
        {
            if (generatedAccount as CheckingAccount != null)
            {
                Console.WriteLine
                ($"Hello { currentUser.FullName }, your new Checking Account Number at Big Bank Inc is { generatedAccount.AccountNumber }");
                System.Console.WriteLine();
            }
            else
            {
                Console.WriteLine
                ($"Hello { currentUser.FullName }, your new Savings Account Number at Big Bank Inc is { generatedAccount.AccountNumber }");
                System.Console.WriteLine();
            }
        }

        private static void OpenAccountDisplayByType (Account generatedAccount)
        {
            Console.WriteLine($"How much would you like to add to open account { generatedAccount.AccountNumber }.");
            System.Console.WriteLine();
        }

        private static decimal IsInitialInvestmentDecimal()
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

        private static void DisplayInitialAccountInvestment(Account generatedAccount)
        {
            Console.WriteLine();

            System.Console.WriteLine($"You added ${ generatedAccount.AccountAmountCurrent } to your savings account { generatedAccount.AccountNumber }.");

            System.Console.WriteLine();
        }

        private static void AccountsMenuHeader()
        {
            System.Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("List of Current Accounts");

            Console.ResetColor();
            System.Console.WriteLine("--------------------------");
        }

        private static void AccountsMenuListOfAccounts()
        {
            var accountListOption = 1;

            foreach (Account act in currentUser.Accounts)
            {

                if (act as CheckingAccount != null)
                {
                    System.Console.WriteLine("{0} - Checking: {1}", accountListOption, act.AccountNumber);

                }

                if (act as SavingsAccount != null)
                {
                    System.Console.WriteLine("{0} - Savings: {1}", accountListOption, act.AccountNumber);

                }

                accountListOption++;
            }
        }

        private static string LastFourAccountDigits()
        {
            System.Console.WriteLine();

            System.Console.WriteLine("Which account above would you like to modify? Please enter the last 4 digits of the account number.");

            return Console.ReadLine();
        }

        public static void ManageAllAccountsUserHeader()
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

        private static Account FindAccountByLastFourDigits(string accountLastFourDigits)
        {
            return currentUser.Accounts.Find(act => act.AccountNumber.ToString().Contains(accountLastFourDigits));
        }

        private static void ListAsCheckingOrSavings(Account selectedAccount)
        {
            if (selectedAccount as CheckingAccount != null)
            {
                System.Console.WriteLine($"Checking Account: {selectedAccount.AccountNumber}");
            }

            if (selectedAccount as SavingsAccount != null)
            {
                System.Console.WriteLine($"Savings Account: {selectedAccount.AccountNumber}");
            }

            System.Console.WriteLine();
        }

        private static void ListOfCheckingAccounts()
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

        private static void ListOfSavingsAccounts ()
        {
            foreach (Account act in currentUser.Accounts)
            {
                if (act as SavingsAccount != null)
                {
                    Console.WriteLine($"{act.AccountNumber} : ${act.AccountAmountCurrent}");
                    totalInAllAccounts += act.AccountAmountCurrent;
                }
            }
        }

        private static void TotalInAllAccounts()
        {
            Console.WriteLine();

            System.Console.WriteLine($"Total Amount of funds deposited currently in bank is ${ totalInAllAccounts }");

            System.Console.WriteLine();
        }

        private static void MainMenuWriter()
        {
            Console.ResetColor();

            System.Console.WriteLine();

            fullMenu.MenuWriter(fullMenu.mainOptionsMenu);

            mainOption = Console.ReadLine();

            System.Console.WriteLine();
        }

        private static void DepositToSelectedAccount(Account selectedAccount)
        {
            bool isDepositDecimal;
            decimal decimalAmountEntered;

            do
            {
                System.Console.WriteLine("How much would you like to deposit?");

                string depositAmount = Console.ReadLine();

                isDepositDecimal = Decimal.TryParse(depositAmount, out decimalAmountEntered);

            } while (!isDepositDecimal);

            selectedAccount.AddToAccount(decimalAmountEntered);

            System.Console.WriteLine($"Your account now has ${ decimalAmountEntered }");
        }

        private static void SubtractFromAccountSelected(Account selectedAccount)
        {
            System.Console.WriteLine($"How much money would you like to withdraw from your account { selectedAccount.AccountNumber }?");

            bool isWithdrawAmountDecimal;
            decimal decimalWithdrawAmount;

            do
            {
                var withdrawAmount = Console.ReadLine();

                isWithdrawAmountDecimal = Decimal.TryParse(withdrawAmount, out decimalWithdrawAmount);

                if (isWithdrawAmountDecimal && decimalWithdrawAmount > selectedAccount.AccountAmountCurrent)
                {
                    System.Console.WriteLine("You cannot withdraw more funds than are currently in this account. Please enter a new amount.");
                }
                else if (isWithdrawAmountDecimal && decimalWithdrawAmount < selectedAccount.AccountAmountCurrent)
                {
                    selectedAccount.SubtractFromAccount(decimalWithdrawAmount);
                    System.Console.WriteLine($"Your new account balance for account { selectedAccount.AccountNumber } is ${ selectedAccount.AccountAmountCurrent }");
                }

            } while (decimalWithdrawAmount > selectedAccount.AccountAmountCurrent);
        }
    }

}
