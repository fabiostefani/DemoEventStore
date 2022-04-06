using DemoEventStore.Dtos;
using DemoEventStore.EventStore;
using DemoEventStore.EventStore.Models;
using DemoEventStore.Models;
using DemoEventStore.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoEventStore.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IEventSourcingRepository _eventSourcingRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
                            IEventSourcingRepository eventSourcingRepository)
        {
            _pedidoRepository = pedidoRepository;
            _eventSourcingRepository = eventSourcingRepository;
        }
        public int SalvarPedido(SalvarPedidoDto pedidoDto)
        {
            var pedido = new Pedido(pedidoDto.DataPedido, pedidoDto.CodigoCliente, pedidoDto.Valor);
            _pedidoRepository.Salvar(pedido);

            pedidoDto.AggregateId = pedido.Id;
            _eventSourcingRepository.SalvarEvento(pedidoDto);

            /////SIMULAÇÃO DE PROCESSAMENTO DO EVENTO DE BAIXA NO ESTOQUE
            var baixarEstoqueEvent = new ProcessarBaixaEstoqueEvent
            {
                AggregateId = pedido.Id,
                CodigoItem = 10,
                DataBaixa = DateTime.Now,
                QtdeBaixado = 10
            };
            _eventSourcingRepository.SalvarEvento(baixarEstoqueEvent);

            var nota = new ProcessarNotaPedidoEvent { AggregateId = pedido.Id, CodigoTransportadora = 10, DataNota = DateTime.Now };
            _eventSourcingRepository.SalvarEvento(nota);

            return pedido.Id;
        }

        public async Task<IEnumerable<StoredEvent>> ObterEventosPedido(int codigoPedido)
        {
            return await _eventSourcingRepository.ObterEventos(codigoPedido);
        }

        public async Task<IEnumerable<Pedido>> ObterTodos() =>
            await _pedidoRepository.ObterTodos();
    }
}
