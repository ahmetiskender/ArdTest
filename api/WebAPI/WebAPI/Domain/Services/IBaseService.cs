using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Domain.Responses;

namespace WebAPI.Domain.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<BaseResponse<T>> GetById(int Id);
        Task<BaseResponse<IEnumerable<T>>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<BaseResponse<T>> Add(T entry);
        Task<BaseResponse<T>> Update(T entry);
        Task<BaseResponse<T>> Delete(int Id);
    }
}