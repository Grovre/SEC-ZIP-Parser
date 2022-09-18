using SEC_ZIP_Parser.Classes.Enums;

namespace SEC_ZIP_Parser.Classes;

public static class ExchangesHelper
{
    public static Exchanges Parse(string exchange)
    {
        Exchanges parsedExchange;
        exchange = exchange.ToLower();
            
        return exchange switch
        {
            "nyse" => Exchanges.Nyse,
            "nasdaq" => Exchanges.Nasdaq,
            _ => Exchanges.Other
        };
    }
}