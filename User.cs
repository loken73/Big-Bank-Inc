using System.Collections.Generic;

namespace Big_Bank_Inc
{
    public class User 
    {

        private string _firstName;

        private string _lastName;
        
        public string FullName 
        { 
            get
            {
                return _firstName + " " + _lastName;
            }
        }

        public string SocialSecurity { get; private set; }

        public List<Account> Accounts = new List<Account>();

        public User(string firstName, string lastName, string sSN)
        {
            _firstName = firstName;
            _lastName = lastName;
            SocialSecurity = sSN;
        }

        public static User CreateUser(string firstName, string lastName, string socialSecurityNumber)
        {
            return new User(firstName, lastName, socialSecurityNumber);
        }
    }   
}
