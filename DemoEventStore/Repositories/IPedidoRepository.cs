using DemoEventStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoEventStore.Repositories
{
    public interface IPedidoRepository
    {
        void Salvar(Pedido pedido);
        Task<IEnumerable<Pedido>> ObterTodos();
    }
}
