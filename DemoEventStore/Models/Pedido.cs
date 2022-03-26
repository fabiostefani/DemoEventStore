using System;

namespace DemoEventStore.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int CodigoCliente { get; set; }
        public decimal Valor { get; set; }
        public Pedido(DateTime dataPedido, int codigoCliente, decimal valor)
        {
            DataPedido = dataPedido;
            CodigoCliente = codigoCliente;
            Valor = valor;
        }
    }
}
