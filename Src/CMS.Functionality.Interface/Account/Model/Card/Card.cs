namespace CMS.Functionality.Interface
{
    public class Card: Account
    {
        public Card() : base(type: AccountType.Card)
        {
        }

        public Card(Account account) : base(id: account.Id, type: AccountType.Card, number: account.Number)
        {
        }
    }
}
