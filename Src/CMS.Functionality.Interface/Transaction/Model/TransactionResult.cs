namespace CMS.Functionality.Interface
{
    public class TransactionResult: Result
    {
        private TransactionResult(bool success, string code = null, string description = null)
        {
            this.Success = success;
            this.Code = code;
            this.Description = description;
        }

        public static TransactionResult SuccessResult = new TransactionResult(success: true);
        public static TransactionResult FailureResult = new TransactionResult(success: false);        
        public static TransactionResult DailyLimitReached = new TransactionResult(success: false, code: "DlTrnLmt", description: "Daily transaction amount Limit has been exceeded");
        public static TransactionResult MonthlyLimitReached = new TransactionResult(success: false, code: "MlnTrnLmt", description: "Monthly transaction amount Limit has been exceeded");
        public static TransactionResult YearlyLimitReached = new TransactionResult(success: false, code: "YlTrnLmt", description: "Yearly transaction amount Limit has been exceeded");

    }
}
