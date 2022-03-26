using DemoEventStore.Context;
using DemoEventStore.Models;
using System.Linq;

namespace DemoEventStore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _context;
        public PedidoRepository(PedidoContext context)
        {
            _context = context;
        }
        public void Salvar(Pedido pedido)
        {
            pedido.Id = ProximoCodigo();
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        int ProximoCodigo() => _context.Pedidos.ToList().Count + 1;
    }
}
