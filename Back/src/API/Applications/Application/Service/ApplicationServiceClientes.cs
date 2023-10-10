using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Applications.Application.DTO.DTO;
using API.Applications.Application.Interface;
using API.Domains.Domain.Core.Services;
using API.Infra.Infra.CrossCutting.Adapter.Interface;

namespace API.Applications.Application.Service
{
    public class ApplicationServiceClientes : IApplicationServiceClientes
    {
        private readonly IServiceCliente _serviceCliente;
        private readonly IMapperCliente _mapperCliente;

        public ApplicationServiceClientes(IServiceCliente serviceCliente, IMapperCliente mapperCliente)
        {
            _serviceCliente = serviceCliente;
            _mapperCliente = mapperCliente;
        }

        public async Task<ClienteDTO> GetByIdAsync(int id)
        {
            try
            {
                var cliente = await _serviceCliente.GetByIdAsync(id);

                if(cliente == null)
                return null;

                return _mapperCliente.MapperToDTO(cliente);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}