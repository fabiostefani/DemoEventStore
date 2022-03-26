using DemoEventStore.Core;
using System;

namespace DemoEventStore.Dtos
{
    public class SalvarPedidoDto : Event
    {
        public DateTime DataPedido { get; set; }
        public int CodigoCliente { get; set; }
        public decimal Valor { get; set; }
    }
}
