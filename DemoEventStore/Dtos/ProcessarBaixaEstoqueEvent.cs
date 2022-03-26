using DemoEventStore.Core;
using System;

namespace DemoEventStore.Dtos
{
    public class ProcessarBaixaEstoqueEvent : Event
    {
        public int CodigoItem { get; set; }
        public DateTime DataBaixa { get; set; }
        public int QtdeBaixado { get; set; }
    }
}
