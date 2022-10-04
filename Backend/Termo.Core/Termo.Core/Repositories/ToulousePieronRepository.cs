using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Termo.Core.Models.ToulousePieron;
using Termo.Core.Repositories.Interfaces;
using Termo.Data;
using Termo.Data.Models;

namespace Termo.Core.Repositories
{
    public class ToulousePieronRepository : GenericRepository<ToulousePieronTest>, IToulousePieronRepository
    {
        private readonly TermoDbContext context;
        private readonly IMapper mapper;

        public ToulousePieronRepository(TermoDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Save(ToulousePieronDto dto)
        {
            #region Check ERRORS
            if (await IsInValidTest(dto.Token))
            {
                return new NotFoundResult();
            }
            if (!CheckTime(dto))
            {
                return new BadRequestResult();
            }
            #endregion
            try
            {
                var entity = mapper.Map<ToulousePieronTest>(dto);
                entity.TestId = (await context.Tests.FirstAsync(x => x.Link == dto.Token)).Id;
                await AddAsync(entity);
                return new OkResult();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
        public async Task<bool> IsInValidTest(string Token)
        {
            return await context.ToulousePieronTests.Where(x => x.Test.Link == Token).AnyAsync()
                || await context.Tests.Where(x=>x.Link != Token).AnyAsync() || await context.Tests.CountAsync() == 0;
        }

        public bool CheckTime(ToulousePieronDto dto)
        {
            TimeSpan ts = dto.EndTime - dto.StartTime;
            return ts.TotalSeconds <= 300 && ts.TotalSeconds > 0;
        }
    }
}
