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
            this._firstName = firstName;
            this._lastName = lastName;
            this.SocialSecurity = sSN;
        }
    }
}
