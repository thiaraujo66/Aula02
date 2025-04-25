using Microsoft.EntityFrameworkCore;
using Aula02.Domain.Models;

namespace Aula02.Infraestrutura.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
