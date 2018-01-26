namespace Big_Bank_Inc
{
    public class SavingsAccount : Account
    {
        public float SavingsAPR => (float)1.5;

        public SavingsAccount(User user)
            :base(user)
        {
            
        }
    }
}
