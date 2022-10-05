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
        public Task<Result> MakeResult(BaseDto dto);
        public Task<AdminResults> MakeAdminResult(BaseDto dto);
        public Task<UserDto> GetUser(BaseDto dto);
        public Task<bool> IsValidLink(string Link);
        public Task<IList<ToulousePieronDto>> GetAllPieronResult(string Link);
        public Task<IList<ChairLampDto>> GetAllChairLampResult(string Link);
        public Task<IList<BourdonDto>> GetAllBourdonResult(string Link);
    }
}
