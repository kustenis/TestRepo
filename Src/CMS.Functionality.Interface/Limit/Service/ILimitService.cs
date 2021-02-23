using System.Threading.Tasks;

namespace CMS.Functionality.Interface
{
    public interface ILimitService
    {
        public Task<LimitResult> RegisterLimitAsync(Limit limit);
        public Task<LimitResult> UpdateLimitAsync(Limit limit);
    }
}
