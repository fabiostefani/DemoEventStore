using DemoEventStore.Core;
using System;

namespace DemoEventStore.Dtos
{
    public class ProcessarNotaPedidoEvent : Event
    {
        public int CodigoTransportadora { get; set; }
        public DateTime DataNota { get; set; }
    }
}
