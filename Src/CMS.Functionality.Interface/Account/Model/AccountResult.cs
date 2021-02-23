namespace CMS.Functionality.Interface
{
    public class AccountResult<T> : Result
    {
        public T Data { get; set; }
        public AccountResult(bool success, string code = null, string description = null, T data = default(T))
        {
            this.Success = success;
            this.Code = code;
            this.Description = description;
            this.Data = data;
        }
        public static AccountResult<T> SuccessResult = new AccountResult<T>(success: true);
        public static AccountResult<T> FailureResult = new AccountResult<T>(success: false);
    }

}
