using System.ComponentModel;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StockMarketProducersService.worker;

class StockMarketProducerWorker : BackgroundService
{
    private readonly ILogger<StockMarketProducerWorker> _logger;

    public StockMarketProducerWorker(ILogger<StockMarketProducerWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker service successfully started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            // Simulate business logic processing delay
            await Task.Delay(5000, stoppingToken); 
        }

        _logger.LogInformation("Worker service is gracefully shutting down.");
    }
}