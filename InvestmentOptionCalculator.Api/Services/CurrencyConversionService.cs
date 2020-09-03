using InvestmentOptionCalculator.Api.Libs.CurrencyRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Services
{
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly ICurrencyRateService _currencyRateService;

        public CurrencyConversionService(ICurrencyRateService currencyRateService)
        {
            this._currencyRateService = currencyRateService;
        }

        public async Task<double> GetAUDToUSDRate()
        {
            var model = await _currencyRateService.GetCurrencyRates("AUD");
            if (model.IsSuccessful)
            {
                return model.Rates.USD;
            }
            else
            {
                return -1;
            }
        }
    }
}
