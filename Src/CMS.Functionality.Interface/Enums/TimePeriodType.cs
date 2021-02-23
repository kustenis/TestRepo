
namespace CMS.Functionality.Interface
{
    public class TimePeriodType
    {
        private string _type { get; }
        
        private TimePeriodType(string type)
        {
            _type = type;
        }

        public override string ToString()
        {
            return _type;
        }

        public override bool Equals(object obj)
        {
            var timePeriodType = obj as TimePeriodType;
            return _type?.ToUpper() == timePeriodType?.ToString()?.ToUpper();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static TimePeriodType Calendar = new TimePeriodType("Calendar");
        public static TimePeriodType Anniversary = new TimePeriodType("Anniversary");
    }
}
