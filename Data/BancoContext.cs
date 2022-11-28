using Microsoft.EntityFrameworkCore;
using PIM_VIII_SQLSERVER.Models;

namespace PIM_VIII_SQLSERVER.Data
{
    public class BancoContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Enderecos> Enderecos { get; set; }

        public DbSet<Telefones> Telefones { get; set; }

        public DbSet<TipoTelefones> TipoTelefones { get; set; }

        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        { 

        }
    }
}
