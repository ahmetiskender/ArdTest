using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Domain.Repositories.MSSQL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ArdTestContext context;
        private DbSet<T> table = null;

        public BaseRepository(ArdTestContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public async Task Add(T entry)
        {
            await table.AddAsync(entry);
        }

        public async Task Delete(int Id)
        {
            T existEntity = await GetById(Id);
            table.Remove(existEntity);
        }

        public async Task<T> GetById(int Id)
        {
            return await table.FindAsync(Id);
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await table.Where(predicate).ToListAsync();
        }

        public void Update(T entry)
        {
            context.Entry(entry).State = EntityState.Modified;
        }
    }
}