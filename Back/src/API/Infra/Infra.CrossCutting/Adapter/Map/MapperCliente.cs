using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Applications.Application.DTO.DTO;
using API.Domains.Domain.Entities;
using API.Infra.Infra.CrossCutting.Adapter.Interface;

namespace API.Infra.Infra.CrossCutting.Adapter.Map
{
    public class MapperCliente : IMapperCliente
    {
        public List<ClienteDTO> MapperListCliente(List<Cliente> lstClientes)
        {
            throw new NotImplementedException();
        }

        public ClienteDTO MapperToDTO(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente MapperToEntity(ClienteDTO clienteDTO)
        {
            throw new NotImplementedException();
        }
    }
}