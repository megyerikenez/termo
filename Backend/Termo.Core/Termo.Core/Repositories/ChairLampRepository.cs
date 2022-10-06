using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Termo.Core.Models.ChairLamp;
using Termo.Core.Repositories.Interfaces;
using Termo.Data;
using Termo.Data.Models;

namespace Termo.Core.Repositories
{
    public class ChairLampRepository : GenericRepository<ChairLampTest>, IChairLampRepository
    {
        private readonly TermoDbContext context;
        private readonly IMapper mapper;

        public ChairLampRepository(TermoDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Save(ChairLampDto dto)
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
                var entity = mapper.Map<ChairLampTest>(dto);
                entity.TestId = (await context.Tests.FirstAsync(x => x.Link == dto.Token)).Id;
                await AddAsync(entity);

                var testId = (await context.ChairLampTests.FirstAsync(x => x.Test.Link == dto.Token)).Id;

                for (int i = 0; i < dto.Values.Count(); i++)
                {
                    context.ChairLampTestItems.Add(new ChairLampTestItem
                    {
                        Minute = i + 1,
                        IncorrectlyIgnored = dto.Values[i].IncorrectlyIgnored,
                        IncorrectlyMarked = dto.Values[i].IncorrectlyMarked,
                        CorrectlyMarked = dto.Values[i].CorrectlyMarked,
                        CorrectlyIgnored = dto.Values[i].CorrectlyIgnored,
                        PicturesRevised = dto.Values[i].PicturesRevised,
                        ChairLampTestId = testId
                    });
                    await context.SaveChangesAsync();
                }
                return new OkResult();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
        public async Task<bool> IsInValidTest(string Token)
        {
            var test = await context.Tests.FirstOrDefaultAsync(x => x.Link == Token);
            if (test == null)
            {
                return true;
            }
            return await context.ChairLampTests.Where(x => x.TestId == test.Id).AnyAsync();
        }
        public bool CheckTime(ChairLampDto dto)
        {
            TimeSpan ts = dto.EndTime - dto.StartTime;
            return ts.TotalSeconds <= 300 && ts.TotalSeconds > 0;
        }
    }
}
