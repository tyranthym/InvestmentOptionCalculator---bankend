using InvestmentOptionCalculator.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    /// <summary>
    /// strategy factory for calculating ROI and fee depends on different option
    /// </summary>
    public interface ICalculationStrategyFactory
    {
        ICalculationStrategy GetCalculationStrategy(Enums.InvestmentOption investmentOptions);
    }
}
