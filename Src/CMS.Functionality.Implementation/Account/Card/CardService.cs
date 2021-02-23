using CMS.Functionality.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Functionality.Implementation
{
    public class CardService : ICardService
    {
        private CmsDbContext _dbContext;

        public CardService(CmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AccountResult<Card>> RegisterCardAsync(CardInfo cardInfo)
        {
            var failedValidation = ValidateCard<Card>(cardInfo);
            if (failedValidation != null) return failedValidation;

            cardInfo.Id = cardInfo.Id ?? Guid.NewGuid();

            _dbContext.Add(cardInfo);

            try
            {
                await _dbContext.SaveChangesAsync();
                return AccountResult<Card>.SuccessResult;
            }
            catch (Exception exception)
            {
                return AccountResult<Card>.FailureResult;
            }
        }

        public async Task<AccountResult<Card>> GetCardAsync(CardInfo cardInfo)
        {
            var failedValidation = ValidateCard<Card>(cardInfo);
            if (failedValidation != null) return failedValidation;

            var account = await _dbContext.Set<Account>()
                .Where(acc => acc.Type == AccountType.Card &&
                              (acc.Number == cardInfo.Number || acc.Id == cardInfo.Id))
                .FirstOrDefaultAsync();
            var card = account != null ? new Card(account) : null;
            return new AccountResult<Card>(success: true, data: card);
        }

        public async Task<AccountResult<IEnumerable<SpendingInfo>>> GetCardSpendingInfoAsync(CardInfo cardInfo)
        {
            var failedValidation = ValidateCard<IEnumerable<SpendingInfo>>(cardInfo);
            if (failedValidation != null) return failedValidation;

            var account = await _dbContext.Set<Account>()
                .Where(acc => acc.Type == AccountType.Card &&
                              (acc.Number == cardInfo.Number || acc.Id == cardInfo.Id))
                .FirstOrDefaultAsync();

            if (account == null) return null;

            var asOfDate = (cardInfo.AsOfDate >= default(DateTime)) ? cardInfo.AsOfDate.Value.Date : DateTime.Today;
            var transactionSpendings = await _dbContext.Set<Transaction>()
                .Where(trn => trn.AccountId == account.Id &&
                              trn.TransactionDate >= asOfDate.ToUniversalTime() &&
                              trn.TransactionDate < asOfDate.AddDays(1).ToUniversalTime())
                .Select(trn => new { trn.Type, trn.Amount })
                .ToListAsync();

            if (!(transactionSpendings?.Count > 0)) return null;

            var spendings = new List<SpendingInfo>();
            foreach (var trnGrp in transactionSpendings.GroupBy(trn => trn.Type))
            {
                spendings.Add(new SpendingInfo { Type = trnGrp.Key, Amount = trnGrp.Sum(item => (item.Amount ?? 0)), AccountNumber = account.Number });
            } 

            return new AccountResult<IEnumerable<SpendingInfo>>(success: true, data: spendings);
        }



        private AccountResult<T> ValidateCard<T>(CardInfo cardInfo)
        {
            if (cardInfo == null) return AccountResult<T>.FailureResult;

            cardInfo.Number = cardInfo.Number?.Trim();
            if (string.IsNullOrEmpty(cardInfo.Number)) return AccountResult<T>.FailureResult;

            return null;
        }
    }
}
