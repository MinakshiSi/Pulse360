using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditService.Domain.Interfaces
{
    public interface ICreditRepository
    {
        Task<int> FetchScoreAsync(Guid userId);
    }
}
