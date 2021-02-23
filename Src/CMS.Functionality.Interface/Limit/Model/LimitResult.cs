namespace CMS.Functionality.Interface
{
    public class LimitResult: Result
    {
        private LimitResult(bool success, string code = null, string description = null)
        {
            this.Success = success;
            this.Code = code;
            this.Description = description;
        }

        public static LimitResult SuccessResult = new LimitResult(success: true);
        public static LimitResult FailureResult = new LimitResult(success: false);

    }
}
