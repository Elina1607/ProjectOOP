namespace ConsoleApplication1.Accounts
{
    public class VipAccount : GameAccount
    {
        public VipAccount(string userName) : base(userName)
        {
        }

        protected override int CalculateRating(int inputRating)
        {
            return inputRating * 2;
        }

        protected override string GetAccountType()
        {
            return "VIP-Акаунт";
        }
    }
}