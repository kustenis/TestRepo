using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Functionality.Interface
{
    public interface ITransactionService
    {
        public Task<TransactionResult> PostTransaction(Transaction transaction);
        public Task<IEnumerable<Transaction>> GetTransactions(AccountInfo accountInfo);
        public Task<decimal> DailyAggregateAmount(AccountInfo accountInfo);
    }
}
