using InvestmentOptionCalculator.Api.Models.BusinessLogic.InvestmentOption;
using InvestmentOptionCalculator.Api.Models.Dtos;
using InvestmentOptionCalculator.Api.Models.Requests;
using InvestmentOptionCalculator.Api.Models.Responses.InvestmentOption;
using InvestmentOptionCalculator.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.ModelMappers
{
    public class InvestmentOptionMapper : IInvestmentOptionMapper
    {
        private readonly IInvestmentOptionService _investmentOptionService;

        public InvestmentOptionMapper(IInvestmentOptionService investmentOptionService)
        {
            this._investmentOptionService = investmentOptionService;
        }

        public List<InvestmentOptionDto> FromCalculateROIRequestToInvestmentOptionDtos(CalculateROIRequest requestModel)
        {
            List<InvestmentOptionDto> investmentOptionDtos = new List<InvestmentOptionDto>();

            foreach (var option in requestModel.Options)
            {
                InvestmentOptionDto investmentOptionDto = new InvestmentOptionDto
                {
                    InvestmentOption = option.InvestmentOption,
                    InvestmentPercentage = option.InvestmentPercentage,
                    InvestmentAmount = _investmentOptionService.CalculateInvestmentAmount(requestModel.TotalAmount, option.InvestmentPercentage)
                };
                investmentOptionDtos.Add(investmentOptionDto);
            }
            return investmentOptionDtos;
        }

        public InvestmentOptionCalculationResponse FromCalculationModelToInvestmentOptionCalculationResponse(CalculationModel calculationModel, string currencyCode)
        {
            var investmentOptionCalculationResponse = new InvestmentOptionCalculationResponse
            {
                CurrencyCode = currencyCode,
                TotalROI = calculationModel.ROI,
                TotalFee = calculationModel.Fee
            };
            return investmentOptionCalculationResponse;
        }
    }
}
