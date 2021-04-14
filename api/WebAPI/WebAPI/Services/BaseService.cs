using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Domain.Repositories.MSSQL;
using WebAPI.Domain.Responses;
using WebAPI.Domain.Services;
using WebAPI.Domain.UnitOfWork;

namespace WebAPI.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> baseRepository;
        private readonly IUnitOfWork unitOfWork;

        public BaseService(IBaseRepository<T> baseRepository, IUnitOfWork unitOfWork)
        {
            this.baseRepository = baseRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<T>> Add(T entry)
        {
            try
            {
                await this.baseRepository.Add(entry);
                await this.unitOfWork.CompleteAsync();

                return new BaseResponse<T>(entry);
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>($"Ekleme işleminde bir hata meydana geldi :: {ex.Message}");
            }
        }

        public async Task<BaseResponse<T>> Delete(int Id)
        {
            try
            {
                T t = await baseRepository.GetById(Id);
                if (t != null)
                {
                    await this.baseRepository.Delete(Id);
                    await this.unitOfWork.CompleteAsync();
                    return new BaseResponse<T>(t);
                }
                else
                {
                    return new BaseResponse<T>("Id'ye ait satır bulunamamıştır.");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>($"Silme işleminde bir hata meydana geldi :: {ex.Message}");
            }
        }

        public async Task<BaseResponse<T>> GetById(int Id)
        {
            try
            {
                T t = await this.baseRepository.GetById(Id);
                if (t != null)
                {
                    return new BaseResponse<T>(t);
                }
                else
                {
                    return new BaseResponse<T>("Id'ye ait satır bulunamamıştır.");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>($"Id'ye ait satır arama işleminde bir hata meydana geldi :: {ex.Message}");
            }
        }

        public async Task<BaseResponse<T>> Update(T entry)
        {
            try
            {
                this.baseRepository.Update(entry);
                await this.unitOfWork.CompleteAsync();
                return new BaseResponse<T>(entry);
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>($"Güncelleme işleminde bir hata meydana geldi :: {ex.Message}");
            }
        }

        public async Task<BaseResponse<IEnumerable<T>>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            try
            {
                IEnumerable<T> t = await this.baseRepository.GetWhere(predicate);
                return new BaseResponse<IEnumerable<T>>(t);
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<T>>($"Sorgunuzda bir hata meydana geldi :: {ex.Message}");
            }
        }
    }
}
