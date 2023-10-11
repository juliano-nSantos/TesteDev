using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domains.Domain.Core.Repositories.Base;
using API.Domains.Domain.Entities;

namespace API.Domains.Domain.Core.Repositories
{
    public interface IRepositoryClientes : IRepositoryBase<Cliente>
    {
        Task<Cliente> GetByEmail(string email);
    }
}