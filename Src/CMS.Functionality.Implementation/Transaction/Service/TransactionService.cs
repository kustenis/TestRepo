using CMS.Functionality.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Functionality.Implementation 
{ 
    public class TransactionService : ITransactionService
    {
        private CmsDbContext _dbContext;

        public TransactionService(CmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TransactionResult> PostTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> DailyAggregateAmount(AccountInfo accountInfo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transaction>> GetTransactions(AccountInfo accountInfo)
        {
            throw new NotImplementedException();
        }

        private TransactionResult ValidateTransaction(Transaction transaction)
        {
            if (transaction == null) return TransactionResult.SuccessResult;

            if (transaction.AccountId == null || transaction.AccountId == Guid.Empty) return TransactionResult.FailureResult;

            if (!(transaction.Amount > 0)) return TransactionResult.FailureResult;

            if (!(transaction.TransactionDate > default(DateTimeOffset))) return TransactionResult.FailureResult;

            if (transaction.Type == null) return TransactionResult.FailureResult;

            return null;
        }
    }
}
