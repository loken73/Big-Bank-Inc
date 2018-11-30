using System;

namespace Big_Bank_Inc
{
    public class Account 
    {
        private int _accountNumber;

        private decimal _currentAmmount;

        private DateTime _startDate;

        private static User _user;

        public int AccountNumber// => _accountNumber;
        { 
            get
            {
                return _accountNumber;
            }
        }

        public decimal AccountAmountCurrent 
        {
            get
            {
                return _currentAmmount;
            }
        }

        public User GetUser() 
        {
            return _user;
        }

        public decimal InitialInvestment (decimal ammount, DateTime startDate)
        {
            _currentAmmount = ammount;

            _startDate = startDate;

            return _currentAmmount;
        }

        public TimeSpan AccountDuration ()
        {
            var timeSpan = DateTime.Now - _startDate;

            var years = timeSpan/365;

            return years;
        }

        public decimal AddToAccount(decimal additionAmmount)
        {
            _currentAmmount += additionAmmount;

            return _currentAmmount;
        }

        public decimal SubtractFromAccount(decimal subtractionAmmount)
        {
            _currentAmmount -= subtractionAmmount;

            return _currentAmmount;
        }

        public Account(User user)
        {
            _user = user;

            var randomNum = new Random();

            _accountNumber = randomNum.Next(100000001, 999999999);
        }

        public static Account CreateAccountByType(string createAccountChoice, User currentUser)
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
          
        }

        public static Account FindAccountByLastFourDigits(string accountLastFourDigits)
        {
            return _user.Accounts.Find(act => act.AccountNumber.ToString().Contains(accountLastFourDigits));
        }
    }
}
