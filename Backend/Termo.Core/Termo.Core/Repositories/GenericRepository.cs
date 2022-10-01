using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Termo.Core.Exceptions;
using Termo.Core.Repositories.Interfaces;
using Termo.Data;

namespace Termo.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TermoDbContext context;
        private readonly IMapper mapper;

        public GenericRepository(TermoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
        {
            var entity = mapper.Map<T>(source);

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return mapper.Map<TResult>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            if (entity is null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<TResult>> GetAllAsync<TResult>()
        {
            return await context.Set<T>()
                .ProjectTo<TResult>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await context.Set<T>().FindAsync(id);
        }

        public async Task<TResult> GetAsync<TResult>(int? id)
        {
            var result = await context.Set<T>().FindAsync(id);
            if (result is null)
            {
                throw new NotFoundException(typeof(T).Name, id.HasValue ? id : "No Key Provided");
            }

            return mapper.Map<TResult>(result);
        }

        public async Task UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
