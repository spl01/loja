using Loja.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loja.API.Persistence
{
    public class ClienteDbContext : DbContext
    {
        public virtual DbSet<Cliente> Cliente { get; set; }

        public ClienteDbContext(DbContextOptions<ClienteDbContext> options): base(options)
        {

        }

    }
}
