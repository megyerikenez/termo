using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Core.Models.Bourdon;
using Termo.Core.Models.ChairLamp;
using Termo.Data.Models;

namespace Termo.Core.Repositories.Interfaces
{
    public interface IBourdonRepository : IGenericRepository<BourdonTest>
    {
        Task<IActionResult> Save(BourdonDto dto);
        Task<bool> IsInValidTest(string Token);
    }
}
