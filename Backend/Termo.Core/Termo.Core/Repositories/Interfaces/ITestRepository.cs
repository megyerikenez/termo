using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Core.Models;
using Termo.Core.Models.Bourdon;
using Termo.Core.Models.ChairLamp;
using Termo.Core.Models.Result;
using Termo.Core.Models.ToulousePieron;
using Termo.Core.Models.User;
using Termo.Data.Models;

namespace Termo.Core.Repositories.Interfaces
{
    public interface ITestRepository : IGenericRepository<Test>
    {
        public Task<Result> MakeResult(string Token);
        public Task<IList<AdminResults>> MakeAdminResult();
        public Task<UserDto> GetUser(BaseDto dto);
        public Task<bool> IsValidLink(string Link);
        public Task<IList<ToulousePieronResult>> GetAllPieronResult(string Link);
        public Task<IList<ChairLampResult>> GetAllChairLampResult(string Link);
        public Task<IList<BourdonResult>> GetAllBourdonResult(string Link);
    }
}
