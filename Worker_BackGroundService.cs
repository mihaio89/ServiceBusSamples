using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerServiceExample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            var serviceBusConnectionString = _configuration.GetValue<string>("ServiceBus:ServiceBusConnectionString");
            var queueName = _configuration.GetValue<string>("ServiceBus:QueueName");
            var clientId = _configuration.GetValue<string>("APIM:clientId");
            var clientSecret = _configuration.GetValue<string>("APIM:clientSecret");
            var tokenEndpoint = _configuration.GetValue<string>("APIM:tokenEndpoint");

            _logger.LogInformation($"ServiceBusConnectionString: {serviceBusConnectionString}");
            _logger.LogInformation($"QueueName: {queueName}");
            _logger.LogInformation($"clientId: {clientId}");
            _logger.LogInformation($"clientSecret: {clientSecret}");
            _logger.LogInformation($"tokenEndpoint: {tokenEndpoint}");

            while (!stoppingToken.IsCancellationRequested)
            {
                // Do some work here...

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
