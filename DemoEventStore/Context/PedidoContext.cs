using DemoEventStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEventStore.Context
{
    public class PedidoContext : DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> dbContext)
            : base(dbContext)
        {

        }

        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidoContext).Assembly);
        }
    }
}
