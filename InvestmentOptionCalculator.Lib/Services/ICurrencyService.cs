using InvestmentOptionCalculator.Lib.JsonModels.Currency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Lib.Services
{
    public interface ICurrencyService
    {
        Task<CurrencyRatesModel> GetCurrencyRates(string countryCode);
    }
}
