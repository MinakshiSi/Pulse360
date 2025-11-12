using CreditService.Domain;
using CreditService.Domain.Interfaces;
using SharedKernel.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditService.Application
{
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _repository;
        private readonly ICacheProvider _cache;

        public CreditService(ICreditRepository repository, ICacheProvider cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<int> GetCreditScoreAsync(Guid userId)
        {
            var cached = await _cache.GetAsync<int>($"credit:{userId}");
            if (cached != default) return cached;

            var score = await _repository.FetchScoreAsync(userId);
            await _cache.SetAsync($"credit:{userId}", score, TimeSpan.FromHours(1));
            return score;
        }
    }

}
