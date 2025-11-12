using CreditService.Domain.Interfaces;
using CreditService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditService.Infrastructure
{
    public class CreditRepository : ICreditRepository
    {
        private readonly SqlDbContext _context;

        public CreditRepository(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<int> FetchScoreAsync(Guid userId)
        {
            var profile = await _context.CreditProfiles.FindAsync(userId);
            return profile?.Score ?? 0;
        }
    }

}
