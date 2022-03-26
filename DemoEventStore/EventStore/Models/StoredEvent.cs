using System;

namespace DemoEventStore.EventStore.Models
{
    public class StoredEvent
    {
        public Guid Id { get; private set; }
        public string Tipo { get; private set; }
        public DateTime DataOcorrencia { get; set; }
        public string Dados { get; private set; }

        public StoredEvent(Guid id, string tipo, DateTime dataOcorrencia, string dados)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.DataOcorrencia = dataOcorrencia;
            this.Dados = dados;
        }
    }

    internal class BaseEvent
    {
        public DateTime Timestamp { get; set; }
    }
}
