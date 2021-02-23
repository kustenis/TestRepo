
using System;

namespace CMS.Functionality.Interface
{
    public class Transaction
    {
        public Guid Id { get; set; }
        
        public TransactionType Type { get; set; }
        
        public Guid AccountId { get; set; }

        public DateTimeOffset TransactionDate { get; set; }
        
        public decimal Amount { get; set; }
        
        public string Currency { get; set; }
    }
}
