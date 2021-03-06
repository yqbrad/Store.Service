namespace Store.EndPoints.API.Configuration
{
    public class ServiceConfig
    {
        public string Id { get; set; } = "Service01";
        public int CacheDuration { get; set; }
        public string HealthCheckRoute { get; set; }
        public string RedisConnectionString { get; set; }
        public SwaggerConfig Swagger { get; set; }
    }
}