using DemoEventStore.Dtos;
using DemoEventStore.EventStore.Models;
using DemoEventStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoEventStore.Services
{
    public interface IPedidoService
    {
        int SalvarPedido(SalvarPedidoDto pedidoDto);
        Task<IEnumerable<StoredEvent>> ObterEventosPedido(int codigoPedido);
        Task<IEnumerable<Pedido>> ObterTodos();
    }
}
