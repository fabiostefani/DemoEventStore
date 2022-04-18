using System;

namespace DemoEventStore.Core
{
    public abstract class Event
    {
        private DateTime Timestamp { get; set; }
        public string MessageType { get; private set; }
        public int AggregateId { get; set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
            MessageType = GetType().Name;
        }
    }
}
