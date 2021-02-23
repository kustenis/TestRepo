namespace CMS.Functionality.Interface
{
    public abstract class Result
    {
        public bool Success { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
