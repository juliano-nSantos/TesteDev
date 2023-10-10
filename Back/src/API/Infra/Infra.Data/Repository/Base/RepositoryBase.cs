using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domains.Domain.Core.Repositories.Base;
using API.Infra.Infra.Data.ConfigData;
using API.Infra.Infra.Data.Data.Context;

namespace API.Infra.Infra.Data.Repository.Base
{
    public abstract class RepositoryBase<TEntity> : BaseData, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _context;

        public RepositoryBase(SqlContext context)
        {
            _context = context;
        }
        
        public virtual Task<bool> AddAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateAsync(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}