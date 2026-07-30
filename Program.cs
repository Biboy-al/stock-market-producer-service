using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using stock_market_producer_service;
using StockMarketProducersService.port;
using StockMarketProducersService.worker;


var builder = Host.CreateApplicationBuilder(args);

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string alphaVantageUrl = config["Apis:AlphaVantage:url"] ?? "";

builder.Services.AddHttpClient<IStockDataProvider, AlphaVantageProvider>( client =>
    client.BaseAddress = new Uri(alphaVantageUrl)
);

builder.Services.AddHostedService<StockMarketProducerWorker>();

var app = builder.Build();

await app.RunAsync();