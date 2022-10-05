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

        public async Task<IList<BourdonResult>> GetAllBourdonResult(string Link)
        {
            IList<BourdonResult> list = new List<BourdonResult>();
            (await context.BourdonTests.Where(x => x.Test.Link == Link).ToListAsync()).ForEach(x =>
            {
                list.Add(mapper.Map<BourdonResult>(x));
            });
            return list;
        }

        public async Task<IList<ChairLampResult>> GetAllChairLampResult(string Link)
        {
            IList<ChairLampResult> list = new List<ChairLampResult>();
            (await context.ChairLampTests.Where(x => x.Test.Link == Link).ToListAsync()).ForEach(async x =>
            {
                var chairLamp = mapper.Map<ChairLampResult>(x);
                chairLamp.Values = new List<ChairLampItemDto>();
                (await context.ChairLampTestItems.Include(x => x.ChairLampTest).Where(x => x.ChairLampTest.Test.Link == Link).ToListAsync()).ForEach(y =>
                {
                    var a = mapper.Map<ChairLampItemDto>(y);
                    chairLamp.Values.Add(a);
                });
                list.Add(mapper.Map<ChairLampResult>(chairLamp));
            });
            return list;
        }

        public async Task<IList<ToulousePieronResult>> GetAllPieronResult(string Link)
        {
            IList<ToulousePieronResult> list = new List<ToulousePieronResult>();
            (await context.ToulousePieronTests.Where(x => x.Test.Link == Link).ToListAsync()).ForEach(x =>
            {
                list.Add(mapper.Map<ToulousePieronResult>(x));
            });
            return list;
        }

        public async Task<bool> IsValidLink(string Link)
        {
            return await context.Tests.Where(x => x.Link == Link).AnyAsync();
        }

        public async Task<Result> MakeResult(string Token)
        {
            return new Result
            {
                ToulousePieronResult = await GetAllPieronResult(Token),
                ChairLampResult = await GetAllChairLampResult(Token),
                BourdonResult = await GetAllBourdonResult(Token)
            };
        }

        public async Task<UserDto> GetUser(BaseDto dto)
        {
            return mapper.Map<UserDto>((await context.Tests.FirstAsync(x => x.Link == dto.Token)).User);
        }

        public async Task<IList<AdminResults>> MakeAdminResult()
        {
            var result = new List<AdminResults>();
            foreach (var test in await GetAllAsync())
            {
                var user = await context.Users.FirstAsync(x => x.Id.Equals(test.UserId));
                result.Add(new AdminResults
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Results = await MakeResult(test.Link)
                });
            }
            return result;
        }
    }
}
