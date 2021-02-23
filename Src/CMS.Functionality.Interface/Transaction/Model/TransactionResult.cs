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

        public TransactionResult SuccessResult = new TransactionResult(success: true);
        public TransactionResult DailyLimitReached = new TransactionResult(success: false, code: "DlTrnLmt", description: "Daily transaction amount Limit has been exceeded");
        public TransactionResult MonthlyLimitReached = new TransactionResult(success: false, code: "MlnTrnLmt", description: "Monthly transaction amount Limit has been exceeded");
        public TransactionResult YearlyLimitReached = new TransactionResult(success: false, code: "YlTrnLmt", description: "Yearly transaction amount Limit has been exceeded");

    }
}
