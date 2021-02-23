using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Functionality.Interface
{
    public interface ICardService
    {
        public Task<AccountResult<Card>> RegisterCardAsync(CardInfo cardInfo);
        public Task<AccountResult<Card>> GetCardAsync(CardInfo cardInfo);
        public Task<AccountResult<IEnumerable<SpendingInfo>>> GetCardSpendingInfoAsync(CardInfo cardInfo);
    }
}
