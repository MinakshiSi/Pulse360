using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditService.Domain
{
    public interface ICreditService
    {
        Task<int> GetCreditScoreAsync(Guid userId);
    }

}
