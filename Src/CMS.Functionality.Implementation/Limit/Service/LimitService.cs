using CMS.Functionality.Interface;
using System;
using System.Threading.Tasks;

namespace CMS.Functionality.Implementation
{
    public class LimitService : ILimitService
    {
        private CmsDbContext _dbContext;

        public LimitService(CmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LimitResult> RegisterLimitAsync(Limit limit)
        {
            var failedValidation = ValidateLimit(limit);
            if (failedValidation != null) return failedValidation;

            limit.Id = limit.Id ?? Guid.NewGuid();

            _dbContext.Add(limit);

            try {
                await _dbContext.SaveChangesAsync();
                return LimitResult.SuccessResult;
            }
            catch (Exception exception) {
                return LimitResult.FailureResult;
            }
        }

        public async Task<LimitResult> UpdateLimitAsync(Limit limit)
        {
            var failedValidation = ValidateLimit(limit);
            if (failedValidation != null) return failedValidation;
            if (limit.Id == null || limit.Id == Guid.Empty) return LimitResult.FailureResult;

            _dbContext.Add(limit);

            try
            {
                await _dbContext.SaveChangesAsync();
                return LimitResult.SuccessResult;
            }
            catch (Exception exception)
            {
                return LimitResult.FailureResult;
            }
        }

        private LimitResult ValidateLimit(Limit limit) {
            if (limit == null) return LimitResult.FailureResult;
            
            if (limit.TransactionType == null) return LimitResult.FailureResult;

            if (!(limit.Value >= 0)) return LimitResult.FailureResult;

            if (!(limit.ApplyingPeriod == null)) return LimitResult.FailureResult;
            
            if (!limit.IsActive.HasValue) return LimitResult.FailureResult;

            return null;
        }
    }
}
