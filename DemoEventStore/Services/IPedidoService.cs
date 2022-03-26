using DemoEventStore.Dtos;
using DemoEventStore.EventStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoEventStore.Services
{
    public interface IPedidoService
    {
        int SalvarPedido(SalvarPedidoDto pedidoDto);
        Task<IEnumerable<StoredEvent>> ObterEventosPedido(int codigoPedido);
    }
}
