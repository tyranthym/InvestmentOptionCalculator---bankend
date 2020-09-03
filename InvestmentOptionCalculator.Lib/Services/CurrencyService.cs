using InvestmentOptionCalculator.Lib.JsonModels.Currency;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace InvestmentOptionCalculator.Lib.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly string _baseUri;
        private readonly string _countryCode;
        private readonly IHttpClientFactory _clientFactory;

        public CurrencyService(IHttpClientFactory clientFactory)
        {
            _baseUri = "https://api.exchangeratesapi.io/latest";
            this._countryCode = countryCode;
            this._clientFactory = clientFactory;
        }

        public Task<CurrencyRatesModel> GetCurrencyRates(string countryCode)
        {
            using (var client = new HttpClient())
            {
                var url = QueryHelpers.AddQueryString(_baseUri, "base", "USD");
                var response = client.GetAsync(url);
            }
                
        }
    }
}
