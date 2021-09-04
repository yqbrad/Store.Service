namespace Store.Infrastructure.Service.EventSourcing
{
    public class EventSourcingOptions
    {
        public string ConnectionString { get; set; }
        public string ApplicationName { get; set; }
    }
}