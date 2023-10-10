using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
                                     .Where(c => c.IdCliente == id)
                                     .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {                 
                throw new Exception("Erro ao consultar cliente por código : " + ex.Message);
            }
        }

        public override async Task<bool> AddAsync(Cliente obj)
        {
            bool retorno = false;
            var _database = GetConnection();
            int clienteId = 0;
            int result = 0;

            try
            {
                CreateInputParameters("NOME", DbType.String, obj.Nome);
                CreateInputParameters("EMAIL", DbType.String, obj.Email);
                CreateInputParameters("LOGOTIPO", DbType.String, obj.LogoTipo);
                CreateInputParameters("DATA_CADASTRO", DbType.DateTime, DateTime.Now);
                CreateInputParameters("ATIVO", DbType.Boolean,obj.Ativo);
                CreateInputParameters("USUARIO", DbType.Int32, obj.UsuarioId);
                
                _database.BeginTran();

                using(DbDataReader reader = await _database.ExecuteReaderAsync(CommandType.StoredProcedure, "PRC_REG_CLIENTES", Parameters))
                {
                    if(reader != null)
                    {
                        if(reader.Read())
                        {
                            clienteId = Convert.ToInt32(reader["IdCliente"]);
                        }
                    }
                }
                
                if(clienteId <= 0 )
                {
                    _database.RollbackTran();

                    throw new Exception("Erro ao cadastrar o Cliente! ");
                }

                foreach (var e in obj.Enderecos)
                {
                    CreateInputParameters("LOGRADOURO", DbType.String, e.Logradouro);
                    CreateInputParameters("NUMERO_LOGRADOURO", DbType.String, e.NumeroLogradouro);
                    CreateInputParameters("COMPLEMENTO", DbType.String, e.Complemento);
                    CreateInputParameters("BAIRRO", DbType.String, e.Bairro);
                    CreateInputParameters("CIDADE", DbType.String, e.Cidade);
                    CreateInputParameters("ESTADO", DbType.String, e.Estado);
                    CreateInputParameters("CEP", DbType.String, e.Cep);
                    CreateInputParameters("PONTO_REFERENCIA", DbType.String, e.PontoReferencia);
                    CreateInputParameters("DATA_CADASTRO", DbType.DateTime, DateTime.Now);
                    CreateInputParameters("ATIVO", DbType.Boolean, e.Ativo);
                    CreateInputParameters("DESCRICAO_ENDERECO", DbType.String, e.DescricaoEndereco);
                    CreateInputParameters("CLIENTE_ID", DbType.Int32, clienteId);

                    result += await _database.ExecuteNoQueryAsync(CommandType.StoredProcedure, "PRC_REG_ENDERECO_CLIENTES", Parameters);
                } 

                if(result > 0)
                {
                    _database.CommitTran();
                    retorno = true;
                }
                else
                {
                    _database.RollbackTran();
                }                
            }
            catch(SqlException sex)
            {
                _database.RollbackTran();
                if(sex.Number == 70000)
                {
                    throw new Exception(sex.Message);
                }
            }
            catch (Exception ex)
            {
                _database.RollbackTran();
                throw new Exception("Erro ao cadastrar o Cliente! " + ex.Message);
            }
            finally
            {
                if(_database != null)
                {
                    _database.Dispose();
                    GC.SuppressFinalize(_database);
                }
            }

            return retorno;
        }
    }
}