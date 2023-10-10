using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domains.Domain.Core.Repositories.Base;
using API.Domains.Domain.Core.Services.Base;

namespace API.Domains.Domain.Services.Services.Base
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<bool> AddAsync(TEntity obj)
        {
            try
            {
                return await _repository.AddAsync(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<bool> UpdateAsync(TEntity obj)
        {
            try
            {
                return await _repository.UpdateAsync(obj);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}