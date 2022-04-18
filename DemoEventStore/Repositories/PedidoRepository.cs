using DemoEventStore.Context;
using DemoEventStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Pedido>> ObterTodos() =>
            await _context.Pedidos.ToListAsync();

        private int ProximoCodigo() => _context.Pedidos.ToList().Count + 1;
    }
}
