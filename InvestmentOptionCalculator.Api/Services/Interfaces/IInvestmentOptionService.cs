using InvestmentOptionCalculator.Api.Models.BusinessLogic.InvestmentOption;
using InvestmentOptionCalculator.Api.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Services
{
    public interface IInvestmentOptionService
    {
        /// <summary>
        /// calculate investment amount for an option
        /// </summary>
        /// <param name="totalInvestmentAmount"></param>
        /// <param name="investmentPercentage"></param>
        /// <returns></returns>
        decimal CalculateInvestmentAmount(decimal totalInvestmentAmount, decimal investmentPercentage);
        CalculationModel CalculateTotalROIAndFee(decimal totalInvestmentAmount, List<InvestmentOptionDto> investmentOptions);
        void CovertTotalROIAndFee(CalculationModel calculationModel, double rate);
    }
}
