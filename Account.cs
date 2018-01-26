using System;

namespace Big_Bank_Inc
{
    public class Account 
    {
        private int _accountNumber;

        private decimal _currentAmmount;

        private DateTime _startDate;

        private User _user;

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
    }
}
