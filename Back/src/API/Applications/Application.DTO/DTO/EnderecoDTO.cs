using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Applications.Application.DTO.DTO
{
    public class EnderecoDTO
    {
        public int IdEndereco { get; set;}
        public string Logradouro { get; set; } = string.Empty;
        public string NumeroLogradouro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string PontoReferencia { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public string Descricao { get; set; } = string.Empty;       
    }
}