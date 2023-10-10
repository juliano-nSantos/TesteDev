using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Applications.Application.DTO.DTO;
using API.Domains.Domain.Entities;

namespace API.Infra.Infra.CrossCutting.Adapter.Interface
{
    public interface IMapperCliente
    {
        Cliente MapperToEntity(ClienteDTO clienteDTO);
        List<ClienteDTO> MapperListCliente(List<Cliente> lstClientes);
        ClienteDTO MapperToDTO(Cliente cliente);
    }
}