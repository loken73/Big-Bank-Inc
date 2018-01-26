namespace Big_Bank_Inc
{
    public class Menu 
    {
        public string [] mainOptionsMenu = new string [] 
        {
            "- Create New User",
            "- Create New Account",
            "- Manage Accounts",
            "- Quit"
        };

        public string [] createAccountOptionsMenu = new string []
        {
            "- Create a New Checking Account",
            "- Create a New Savings Account",
        };

        public string[] manageAccountOptionsMenu = new string []
        {
            "- Manage an Existing Account",
            "- Check Balances"
        };

        public string [] individualAccountOptions = new string []
        {
            "- Deposit to selected Account",
            "- Withdraw from selected account"
        };

        public void MenuWriter (string[] menuArray)
        {
            for(int i = 0; i <= menuArray.Length - 1; i++)
            {
                var optionNumber = i+1;

                System.Console.WriteLine("{0} {1}", optionNumber, menuArray[i]);
            }
        }


    }

}