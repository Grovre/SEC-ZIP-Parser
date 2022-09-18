using SEC_ZIP_Parser.Classes.Enums;

namespace SEC_ZIP_Parser.Classes.Helpers;

public static class ExchangesHelper
{
    public static Exchanges Parse(string exchange)
    {
        exchange = exchange.ToLower();
            
        return exchange switch
        {
            "nyse" => Exchanges.Nyse,
            "nasdaq" => Exchanges.Nasdaq,
            _ => Exchanges.Other
        };
    }
}