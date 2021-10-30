
namespace Security.Service.API.Configuration
{
    public class AppSettings
    {
        public string ConnectionString { get; set;}

        public RabbitMQSettings RabbitMQSettings { get; set; }
    }
    
	public class RabbitMQSettings
    {
        public string AmqpUri { get; set;}        
    }

}
