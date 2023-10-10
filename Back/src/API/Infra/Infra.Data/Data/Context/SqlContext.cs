using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domains.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infra.Infra.Data.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) {}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .EnableSensitiveDataLogging()
                    .UseSqlServer("Server=JULIANO-PC;Database=ThomasGregDb;user id=sa;password=123456;Trusted_Connection=false;");
        }

        public DbSet<Cliente> Clientes {get; set;} = null!;
        public DbSet<Endereco> Enderecos { get; set; } = null!;
    }
}