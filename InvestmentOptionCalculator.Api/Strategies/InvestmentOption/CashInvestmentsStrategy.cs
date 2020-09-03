using InvestmentOptionCalculator.Api.Models.BusinessLogic.InvestmentOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    public class CashInvestmentsStrategy : ICalculationStrategy
    {
        public decimal CalculateFee(decimal investmentPercentage, decimal roi)
        {
            if (investmentPercentage > 0 && investmentPercentage <= 0.5M)
            {
                return roi * 0.005M;   //0.5%
            }
            else
            {
                return 0.0M;      //Waived
            }
        }

        public decimal CalculateROI(decimal investmentPercentage, decimal investmentAmount)
        {
            if (investmentPercentage > 0 && investmentPercentage <= 0.5M)
            {
                return investmentAmount * 0.085M;  //8.5%
            }
            else
            {
                return investmentAmount * 0.1M;  //10%
            }
        }
    }
}
