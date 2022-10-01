﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termo.Core.Repositories.Interfaces;
using Termo.Data;
using Termo.Data.Models;

namespace Termo.Core.Repositories
{
    public class ToulousePieronRepository : GenericRepository<ToulousePieronTest>, IToulousePieronRepository
    {
        public ToulousePieronRepository(TermoDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}