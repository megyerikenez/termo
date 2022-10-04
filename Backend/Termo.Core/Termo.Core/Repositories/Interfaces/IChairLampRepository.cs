using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Core.Models.ToulousePieron;
using Termo.Core.Models;
using Termo.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Termo.Core.Models.ChairLamp;

namespace Termo.Core.Repositories.Interfaces
{
    public interface IChairLampRepository : IGenericRepository<ChairLampTest>
    {
        Task<IActionResult> Save(ChairLampDto dto);
        Task<bool> IsInValidTest(string Token);
    }
}
