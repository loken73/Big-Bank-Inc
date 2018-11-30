using System;
using System.Collections.Generic;

namespace Big_Bank_Inc
{
    class Program
    {

        private static string mainOption = "";

        private static decimal totalInAllAccounts;

        private static User currentUser = null;

        static void Main(string[] args)
        {
            do 
            {
                Menu.MainMenuWriter("");
               
                //Create User Option
                if (mainOption == "1")
                {
                    string firstName = Validator.ValidateNameGiven("fn");

                    string lastName = Validator.ValidateNameGiven("ln");

                    string socialSecurityNumber = Validator.ValidateUserSsn();

                    currentUser = User.CreateUser(firstName, lastName, socialSecurityNumber);              
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
                        Menu.MenuWriter(Menu.createAccountOptionsMenu);
                        createAccountOption = Console.ReadLine();

                        System.Console.WriteLine();

                        //Create Checking Account Option
                        if (createAccountOption == "1")
                        {
                            Account checkingAccount = Account.CreateAccountByType(createAccountOption, currentUser);

                            Menu.OpenAccountDisplayByType(checkingAccount);

                            decimal openingAmount = Validator.IsInitialInvestmentDecimal();

                            checkingAccount.InitialInvestment(openingAmount, new DateTime(2015, 01, 01));

                            Menu.DisplayInitialAccountInvestment(checkingAccount);
                        }

                        //Create Savings Account 
                        if (createAccountOption == "2")
                        {

                            Account savingsAccount = Account.CreateAccountByType(createAccountOption, currentUser);

                            Menu.OpenAccountDisplayByType(savingsAccount);

                            decimal openingAmount = Validator.IsInitialInvestmentDecimal();

                            savingsAccount.InitialInvestment(openingAmount, new DateTime(2015, 01, 01));

                            Menu.DisplayInitialAccountInvestment(savingsAccount);

                        }
                    }
                }
                //Manage Accounts Option
                if (mainOption == "3")
                {
                    var manageAccountChoice = "";

                    Menu.MenuWriter(Menu.manageAccountOptionsMenu);

                    manageAccountChoice = Console.ReadLine();

                    System.Console.WriteLine();

                    //Manage an Individual Checking or Savings Account Option
                    if (manageAccountChoice == "1")
                    {
                        Menu.AccountsMenuHeader();

                        Menu.AccountsMenuListOfAccounts(currentUser);

                        string accountLastFourDigits = Menu.LastFourAccountDigits();

                        Account selectedAccount = Account.FindAccountByLastFourDigits(accountLastFourDigits);

                        if (selectedAccount != null)
                        {
                            ListAsCheckingOrSavings(selectedAccount);

                            Menu.MenuWriter(Menu.individualAccountOptions);

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
                        Menu.ManageAllAccountsUserHeader(currentUser);

                        //Bools to check if either a savings or checking account exist in the current users list of accounts
                        var checkingIsInList = currentUser.Accounts.Exists(act => act as CheckingAccount != null);
                        var savingsIsInList = currentUser.Accounts.Exists(act => act as SavingsAccount != null);

                        if (checkingIsInList)
                        {                           
                            Menu.ManageAccountsCheckingAccountListHeader();

                            Menu.ListOfCheckingAccounts(currentUser, totalInAllAccounts);
                        }

                        System.Console.WriteLine();

                        if (savingsIsInList)
                        {
                            Menu.ManageAccountsSavingsAccountListHeader();

                            ListOfSavingsAccounts();

                        }

                        Menu.TotalInAllAccounts(totalInAllAccounts);
                    }
                }

            //Main Menu Option 4 is to Quit Program
            } while (mainOption != "4");
        }


        /*                       Private Static Functions for Refactoring
        ======================================================================================================
         */


        #region

        private static void ListAsCheckingOrSavings(Account selectedAccount)
        {
            if (selectedAccount as CheckingAccount != null)
            {
                Console.WriteLine($"Checking Account: {selectedAccount.AccountNumber}");
            }

            if (selectedAccount as SavingsAccount != null)
            {
                Console.WriteLine($"Savings Account: {selectedAccount.AccountNumber}");
            }

            Console.WriteLine();
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

        private static void DepositToSelectedAccount(Account selectedAccount)
        {
            bool isDepositDecimal;
            decimal decimalAmountEntered;

            do
            {
                Console.WriteLine("How much would you like to deposit?");

                string depositAmount = Console.ReadLine();

                isDepositDecimal = Decimal.TryParse(depositAmount, out decimalAmountEntered);

            } while (!isDepositDecimal);

            selectedAccount.AddToAccount(decimalAmountEntered);

            Console.WriteLine($"Your account now has ${ decimalAmountEntered }");
        }

        private static void SubtractFromAccountSelected(Account selectedAccount)
        {
            Console.WriteLine($"How much money would you like to withdraw from your account { selectedAccount.AccountNumber }?");

            bool isWithdrawAmountDecimal;
            decimal decimalWithdrawAmount;

            do
            {
                var withdrawAmount = Console.ReadLine();

                isWithdrawAmountDecimal = Decimal.TryParse(withdrawAmount, out decimalWithdrawAmount);

                if (isWithdrawAmountDecimal && decimalWithdrawAmount > selectedAccount.AccountAmountCurrent)
                {
                    Console.WriteLine("You cannot withdraw more funds than are currently in this account. Please enter a new amount.");
                }
                else if (isWithdrawAmountDecimal && decimalWithdrawAmount < selectedAccount.AccountAmountCurrent)
                {
                    selectedAccount.SubtractFromAccount(decimalWithdrawAmount);
                    Console.WriteLine($"Your new account balance for account { selectedAccount.AccountNumber } is ${ selectedAccount.AccountAmountCurrent }");
                }

            } while (decimalWithdrawAmount > selectedAccount.AccountAmountCurrent);
        }
        #endregion
    }

}