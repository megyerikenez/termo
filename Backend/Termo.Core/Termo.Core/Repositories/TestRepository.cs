using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
using Termo.Core.Repositories.Interfaces;
using Termo.Data;
using Termo.Data.Models;

namespace Termo.Core.Repositories
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        private readonly TermoDbContext context;
        private readonly IMapper mapper;

        public TestRepository(TermoDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IList<BourdonDto>> GetAllBourdonResult(string Link)
        {
            IList<BourdonDto> list = new List<BourdonDto>();
            (await context.BourdonTests.Where(x => x.Test.Link == Link).ToListAsync()).ForEach(x =>
            {
                list.Add(mapper.Map<BourdonDto>(x));
            });
            return list;
        }

        public async Task<IList<ChairLampDto>> GetAllChairLampResult(string Link)
        {
            IList<ChairLampDto> list = new List<ChairLampDto>();
            (await context.BourdonTests.Where(x => x.Test.Link == Link).ToListAsync()).ForEach(x =>
            {
                list.Add(mapper.Map<ChairLampDto>(x));
            });
            return list;
        }

        public async Task<IList<ToulousePieronDto>> GetAllPieronResult(string Link)
        {
            IList<ToulousePieronDto> list = new List<ToulousePieronDto>();
            (await context.BourdonTests.Where(x => x.Test.Link == Link).ToListAsync()).ForEach(x =>
            {
                list.Add(mapper.Map<ToulousePieronDto>(x));
            });
            return list;
        }

        public async Task<bool> IsValidLink(string Link)
        {
            return await context.Tests.Where(x => x.Link == Link).AnyAsync();
        }

        public async Task<Result> MakeResult(BaseDto dto)
        {
            return new Result
            {
                ToulousePieronResult = await GetAllPieronResult(dto.Token),
                ChairLampResult = await GetAllChairLampResult(dto.Token),
                BourdonResult = await GetAllBourdonResult(dto.Token)
            };
        }

        public async Task<UserDto> GetUser(BaseDto dto)
        {
            return mapper.Map<UserDto>((await context.Tests.FirstAsync(x => x.Link == dto.Token)).User);
        }

        public async Task<AdminResults> MakeAdminResult(BaseDto dto)
        {
            var user = await GetUser(dto);
            return new AdminResults
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Results = await MakeResult(dto)
            };
        }
    }
}
