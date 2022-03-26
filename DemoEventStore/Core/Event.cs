using System;

namespace DemoEventStore.Core
{
    public abstract class Event
    {
        public DateTime Timestamp { get; private set; }
        public string MessageType { get; private set; }
        public int AggregateId { get; set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
            MessageType = GetType().Name;
        }
    }
}
