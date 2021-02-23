using System;

namespace CMS.Functionality.Interface
{
    public class Limit
    {
        public Guid? Id { get; set; }

        public TransactionType? TransactionType { get; set; }

        public decimal? Value { get; }

        public TimePeriod ApplyingPeriod { get; set; }
        
        public bool? IsActive { get; set; }
    }
}
