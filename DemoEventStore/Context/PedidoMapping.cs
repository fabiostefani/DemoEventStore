using DemoEventStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEventStore.Context
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("PEDIDO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired();
        }
    }
}
