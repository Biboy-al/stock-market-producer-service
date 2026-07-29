using System.Security.Cryptography;
using StockMarketProducersService.model;

namespace StockMarketProducersService.port;

interface IStockDataProvider{
    
    public Task<StockPrice> GetPriceAsync(string symbol);

    public Task<StockPrice> GetRecentPriceAsync();

    //Continual Listen to 
    public Task<StockPrice> StreamPricesAsync();
}