using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Services
{
    public interface ICurrencyConversionService
    {
        /// <summary>
        /// get aud: usd rate from 3rd-party api
        /// </summary>
        /// <returns></returns>
        Task<double> GetAUDToUSDRate();
    }
}
