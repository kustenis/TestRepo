using System;

namespace CMS.Functionality.Interface
{
    public class Account
    {
        public Guid Id { get;}
        public AccountType Type { get;}
        public string Number { get;}

        public Account(AccountType type)
        {
            Type = type;
        }

        public Account(Guid id, AccountType type, string number)
        {
            Id = id;
            Type = type;
            Number = number;
        }

        public Account(Account account)
        {
            Id = account.Id;
            Type = account.Type;
            Number = account.Number;
        }
    }
}
