using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Applications.Application.DTO.DTO
{
    public class ClienteDTO
    {
        public ClienteDTO()
        {
            Enderecos = new List<EnderecoDTO>();
        }

        public int IdMotorista { get; set;  }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LogoTipo { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public int UsuarioId { get; set; }

        public List<EnderecoDTO> Enderecos { get; set; } = null!;
    }
}