using DemoEventStore.Core;
using DemoEventStore.EventStore.Models;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEventStore.EventStore
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        private readonly IEventStoreService _eventStoreService;
        public EventSourcingRepository(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;

        }
        public async Task<IEnumerable<StoredEvent>> ObterEventos(int aggregateId)
        {
            var eventos = await _eventStoreService.GetConnection()
                .ReadStreamEventsForwardAsync(aggregateId.ToString(), 0, 500, false);

            List<StoredEvent> listaEventos = (from resolvedEvent in eventos.Events 
                let dataEncoded = Encoding.UTF8.GetString(resolvedEvent.Event.Data) 
                let jsonData = JsonConvert.DeserializeObject<BaseEvent>(dataEncoded) 
                select new StoredEvent(resolvedEvent.Event.EventId, resolvedEvent.Event.EventType, jsonData.Timestamp, dataEncoded)
                ).ToList();

            return listaEventos.OrderBy(e => e.DataOcorrencia);
        }

        public async Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            await _eventStoreService.GetConnection().AppendToStreamAsync(
                evento.AggregateId.ToString(),
                ExpectedVersion.Any,
                FormatarEvento(evento)
            );
        }

        private static IEnumerable<EventData> FormatarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            yield return new EventData(
                Guid.NewGuid(),
                evento.MessageType,
                true,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(evento)),
                null);
        }
    }
}
