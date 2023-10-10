using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domains.Domain.Entities.Base;

namespace API.Domains.Domain.Entities
{
    public class Endereco : Entity
    {
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

        public int ClienteId { get; set; }

        public Cliente Clientes { get; set;} = null!;
    }
}