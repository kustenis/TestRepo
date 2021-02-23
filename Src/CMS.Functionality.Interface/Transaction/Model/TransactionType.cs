namespace CMS.Functionality.Interface
{
    public class TransactionType
    {
        private string _type { get; }

        private TransactionType(string type)
        {
            _type = type;
        }

        public override string ToString()
        {
            return _type;
        }

        public override bool Equals(object obj)
        {
            var transactionType = obj as TransactionType;
            return _type?.ToUpper() == transactionType?.ToString()?.ToUpper();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static TransactionType CardPresent = new TransactionType("CardPresent");
        public static TransactionType Ecommerce = new TransactionType("Ecommerce");
    }
}