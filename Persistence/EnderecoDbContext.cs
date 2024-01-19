using Loja.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loja.API.Persistence
{
    public class EnderecoDbContext : DbContext
    {
        public virtual DbSet<Endereco> Endereco { get; set; }

        public EnderecoDbContext(DbContextOptions<EnderecoDbContext> options): base(options)
        {

        }

    }
}
