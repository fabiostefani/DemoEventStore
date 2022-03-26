using DemoEventStore.Core;
using DemoEventStore.EventStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoEventStore.EventStore
{
    public interface IEventSourcingRepository
    {
        Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event;
        Task<IEnumerable<StoredEvent>> ObterEventos(int aggregateId);
    }
}
