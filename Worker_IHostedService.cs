using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerServiceExample
{
    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker service started");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker service stopped");
            return Task.CompletedTask;
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            // Access the configuration values using the IConfiguration instance
            string serviceBusConnectionString = _configuration["ServiceBus:ServiceBusConnectionString"];
            string queueName = _configuration["ServiceBus:QueueName"];
            string clientId = _configuration["APIM:clientId"];
            string clientSecret = _configuration["APIM:clientSecret"];
            string tokenEndpoint = _configuration["APIM:tokenEndpoint"];

            // Your worker service logic goes here
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.UtcNow);
                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}
