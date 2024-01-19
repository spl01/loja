using Loja.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loja.API.Persistence
{
    public class ContatoDbContext : DbContext
    {
        public virtual DbSet<Contato> Contato { get; set; }

        public ContatoDbContext(DbContextOptions<ContatoDbContext> options): base(options)
        {

        }

    }
}
