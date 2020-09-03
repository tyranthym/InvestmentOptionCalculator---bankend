using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Libs.CurrencyRate
{
    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly string _baseUri;
        private readonly IHttpClientFactory _clientFactory;

        public CurrencyRateService(IHttpClientFactory clientFactory)
        {
            _baseUri = "https://api.exchangeratesapi.io/latest";
            this._clientFactory = clientFactory;
        }

        public async Task<CurrencyRatesModel> GetCurrencyRates(string countryCode)
        {           
            var url = QueryHelpers.AddQueryString(_baseUri, "base", countryCode);
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(url);
            CurrencyRatesModel currencyRatesModel = new CurrencyRatesModel();

            if (response.IsSuccessStatusCode)
            {
                string json = string.Empty;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                currencyRatesModel = JsonConvert.DeserializeObject<CurrencyRatesModel>(json);
                currencyRatesModel.IsSuccessful = true;
            }           
            return currencyRatesModel;
        }
    }
}
