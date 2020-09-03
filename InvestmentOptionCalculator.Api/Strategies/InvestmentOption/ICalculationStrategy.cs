using InvestmentOptionCalculator.Api.Models.BusinessLogic.InvestmentOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    public interface ICalculationStrategy
    {
        decimal CalculateROI(decimal investmentPercentage, decimal investmentAmount);
        decimal CalculateFee(decimal investmentPercentage, decimal roi);
    }
}
