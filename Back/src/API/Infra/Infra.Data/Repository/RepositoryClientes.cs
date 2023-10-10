using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domains.Domain.Core.Repositories;
using API.Domains.Domain.Entities;
using API.Infra.Infra.Data.Data.Context;
using API.Infra.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace API.Infra.Infra.Data.Repository
{
    public class RepositoryClientes : RepositoryBase<Cliente>, IRepositoryClientes
    {
        private readonly SqlContext _context;

        public RepositoryClientes(SqlContext context)
                    : base(context)
        {
            _context = context;
        }

        public override async Task<List<Cliente>> GetAllAsync()
        {
            try
            {
                              
                return await _context.Clientes
                                    .DefaultIfEmpty()
                                    .AsTracking()                                    
                                    .ToListAsync();               
            }
            catch (Exception ex)
            {                
                throw new Exception("Erro ao consultar todos os clientes : " + ex.Message);
            }
        }

        public override async Task<Cliente> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Clientes                                     
                                     .AsNoTracking()
                                     .Include(e => e.Enderecos)
                                     .Where(c => c.Id == id)
                                     .SingleAsync();
            }
            catch (Exception ex)
            {                 
                throw new Exception("Erro ao consultar cliente por código : " + ex.Message);
            }
        }
    }
}