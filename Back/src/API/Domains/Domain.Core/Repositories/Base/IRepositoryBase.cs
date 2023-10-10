using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domains.Domain.Core.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<bool> AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<bool> UpdateAsync(TEntity obj);
        Task<bool> DeleteAsync(int id);
    }
}