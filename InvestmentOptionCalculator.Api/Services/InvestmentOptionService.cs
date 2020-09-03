using InvestmentOptionCalculator.Api.Constants;
using InvestmentOptionCalculator.Api.Enums;
using InvestmentOptionCalculator.Api.Models.BusinessLogic.InvestmentOption;
using InvestmentOptionCalculator.Api.Models.Dtos;
using InvestmentOptionCalculator.Api.Strategies.InvestmentOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Services
{
    public class InvestmentOptionService : IInvestmentOptionService
    {
        private readonly ICalculationStrategyFactory _calculationStrategyFactory;
        private readonly decimal _baseFee = 250.0M;

        public InvestmentOptionService(ICalculationStrategyFactory calculationStrategyFactory)
        {
            this._calculationStrategyFactory = calculationStrategyFactory;
        }

        public decimal CalculateInvestmentAmount(decimal totalInvestmentAmount, decimal investmentPercentage)
        {
            return (totalInvestmentAmount * investmentPercentage) / 100;
        }

        /// <summary>
        /// calculate result for individual investment option
        /// </summary>
        /// <param name="investmentOptionDto"></param>
        /// <returns></returns>
        public CalculationModel CalculateROIAndFeeForOption(InvestmentOptionDto investmentOptionDto)
        {
            var interestCalculationStrategy = _calculationStrategyFactory.GetCalculationStrategy(investmentOptionDto.InvestmentOption);
            CalculationModel calculationModel = new CalculationModel
            {
                ROI = interestCalculationStrategy.CalculateROI(investmentOptionDto.InvestmentPercentage, investmentOptionDto.InvestmentAmount)
            };
            calculationModel.Fee = interestCalculationStrategy.CalculateFee(investmentOptionDto.InvestmentPercentage, calculationModel.ROI);
            return calculationModel;
        }

        public CalculationModel CalculateTotalROIAndFee(decimal totalInvestmentAmount, List<InvestmentOptionDto> investmentOptions)
        {
            CalculationModel calculationModel = new CalculationModel();   //this will hold total ROI and total fee
            foreach (var option in investmentOptions)
            {
                var individualCalculationModel = CalculateROIAndFeeForOption(option);
                calculationModel.ROI += individualCalculationModel.ROI;
                calculationModel.Fee += individualCalculationModel.Fee;
            }
            calculationModel.Fee += _baseFee;
            return calculationModel;
        }

        public void CovertTotalROIAndFee(CalculationModel calculationModel, double rate)
        {
            calculationModel.ROI = decimal.Round(calculationModel.ROI * (decimal)rate, 2);
            calculationModel.Fee = decimal.Round(calculationModel.Fee * (decimal)rate, 2);
        }
    }
}
