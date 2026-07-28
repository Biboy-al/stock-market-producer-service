
using StockMarketProducersService.model;
using StockMarketProducersService.port;

namespace StockMarketProducersService.service; 

class StockProducerServiceImpl : IStockPriceService
{
    IStockProducer producer;

    public StockProducerServiceImpl(IStockProducer producer){
        this.producer = producer;
    }

    public void publicStockPriceService(StockPrice price)
    {
        throw new NotImplementedException();
    }
}