using System;

namespace CMS.Functionality.Interface
{
    public class AccountInfo
    {
        public Guid? Id { get; set; }
        public string Number { get; set; }
        public DateTime? AsOfDate { get; set; }
    }
}