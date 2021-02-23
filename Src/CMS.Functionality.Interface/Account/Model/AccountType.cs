namespace CMS.Functionality.Interface
{
    public class AccountType
    {
        private string _type { get; }

        private AccountType(string type)
        {
            _type = type;
        }

        public override string ToString()
        {
            return _type;
        }

        public static AccountType Card = new AccountType("Card");
    }
}