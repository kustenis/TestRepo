
namespace CMS.Functionality.Interface
{
    public class TimePeriod
    {
        private string _period { get; }
        
        private TimePeriod(string period)
        {
            _period = period;
        }

        public override string ToString()
        {
            return _period;
        }

        public override bool Equals(object obj)
        {
            var timePeriod = obj as TimePeriod;
            return _period?.ToUpper() == timePeriod?.ToString()?.ToUpper();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static TimePeriod Month = new TimePeriod("Month");
        public static TimePeriod Year = new TimePeriod("Year");
        public static TimePeriod Semester = new TimePeriod("Semester");
        public static TimePeriod Quarter = new TimePeriod("Quarter");
    }
}
