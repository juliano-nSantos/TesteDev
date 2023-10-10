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

        public DbSet<Cliente> Clientes {get; set;} = null!;
        public DbSet<Endereco> Enderecos { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .EnableSensitiveDataLogging()
                    .UseSqlServer("Server=PAX00008\\SQLEXPRESS;Database=ThomasGregDb;user id=sa;password=135451;Trusted_Connection=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.IdCliente);
            
            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.IdEndereco);
        }
    }
}