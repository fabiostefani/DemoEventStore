using EventStore.ClientAPI;

namespace DemoEventStore.EventStore
{
    public interface IEventStoreService
    {
        IEventStoreConnection GetConnection();
    }
}
