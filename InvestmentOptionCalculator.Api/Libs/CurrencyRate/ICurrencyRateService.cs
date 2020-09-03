using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Libs.CurrencyRate
{
    public interface ICurrencyRateService
    {
        Task<CurrencyRatesModel> GetCurrencyRates(string countryCode);
    }
}
