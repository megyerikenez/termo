using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Core.Models;
using Termo.Core.Models.ToulousePieron;
using Termo.Data.Models;

namespace Termo.Core.Repositories.Interfaces
{
    public interface IToulousePieronRepository : IGenericRepository<ToulousePieronTest>
    {
        Task<RequestM> Save(ToulousePieronDto dto);
        Task<bool> IsInValidTest(string Token);
    }
}
