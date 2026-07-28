namespace StockMarketProducersService.port;
using StockMarketProducersService.model;

interface IStockProducer
{
    void pusblish(StockPrice price);
}