using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Domain.Repositories.MSSQL
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int Id);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task Add(T entry);
        Task Delete(int Id);
        void Update(T entry);
    }
}