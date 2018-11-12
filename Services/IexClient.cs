using System;
using System.Net.Http;

public class IexClient
{
    public HttpClient Client { get; private set; }
    
    public IexClient(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("https://api.iextrading.com/1.0/stock/");
        Client = httpClient;
    }

    public string filtrar(string accion){
        
        return $"{accion}/batch?types=quote,logo&filter=symbol,companyName,latestPrice,logo";
    }
}