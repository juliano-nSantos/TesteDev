using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domains.Domain.Core.Repositories;
using API.Domains.Domain.Core.Services;
using API.Domains.Domain.Entities;
using API.Domains.Domain.Services.Services.Base;

namespace API.Domains.Domain.Services.Services
{
    public class ServiceClientes : ServiceBase<Cliente>, IServiceCliente
    {
        private readonly IRepositoryClientes _repository;

        public ServiceClientes(IRepositoryClientes repository)
                    : base(repository)
        {
            _repository = repository;
        }

        public override async Task<Cliente> GetByIdAsync(int id)
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

        public override async Task<bool> AddAsync(Cliente obj)
        {
            try
            {
                var cli = await _repository.GetByEmail(obj.Email);

                if (cli != null)
                    throw new ArgumentException("Email informado já está cadastrado!");

                return await _repository.AddAsync(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}