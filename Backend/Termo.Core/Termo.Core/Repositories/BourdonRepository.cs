using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Core.Models.Bourdon;
using Termo.Core.Models.ChairLamp;
using Termo.Core.Repositories.Interfaces;
using Termo.Data;
using Termo.Data.Models;

namespace Termo.Core.Repositories
{
    public class BourdonRepository : GenericRepository<BourdonTest>, IBourdonRepository
    {
        private readonly TermoDbContext context;
        private readonly IMapper mapper;

        public BourdonRepository(TermoDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Save(BourdonDto dto)
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
                var entity = mapper.Map<BourdonTest>(dto);
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
            return await context.ChairLampTests.Where(x => x.Test.Link == Token).AnyAsync()
                || await context.Tests.Where(x => x.Link != Token).AnyAsync() || !await context.Tests.AnyAsync();
        }

        public bool CheckTime(BourdonDto dto)
        {
            TimeSpan ts = dto.EndTime - dto.StartTime;
            return ts.TotalSeconds <= 300 && ts.TotalSeconds > 0;
        }
    }
}
