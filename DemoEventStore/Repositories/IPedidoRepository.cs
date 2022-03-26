using DemoEventStore.Models;

namespace DemoEventStore.Repositories
{
    public interface IPedidoRepository
    {
        void Salvar(Pedido pedido);
    }
}
