using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Applications.Application.DTO.DTO;

namespace API.Applications.Application.Interface
{
    public interface IApplicationServiceClientes
    {
        Task<ClienteDTO> GetByIdAsync(int id);
        Task<bool> AddAsync(ClienteDTO clienteDTO);
    }
}