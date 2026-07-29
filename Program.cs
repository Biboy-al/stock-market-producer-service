using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stock_market_producer_service;
using StockMarketProducersService.port;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

ServiceCollection services = new ServiceCollection();

string alphaVantageUrl = config["Apis:AlphaVantage:url"];

services.AddSingleton<IStockDataProvider, AlphaVantageProvider>();
services.AddHttpClient<IStockDataProvider, AlphaVantageProvider>( client =>
    client.BaseAddress = new Uri(alphaVantageUrl)
);

//Buildes the DI Container
var provider = services.BuildServiceProvider();ß