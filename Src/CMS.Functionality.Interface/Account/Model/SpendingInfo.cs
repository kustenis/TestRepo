namespace CMS.Functionality.Interface
{ 
    public class SpendingInfo
    {
        public TransactionType Type { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
