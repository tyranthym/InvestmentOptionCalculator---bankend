using InvestmentOptionCalculator.Api.Models.BusinessLogic.InvestmentOption;
using InvestmentOptionCalculator.Api.Models.Dtos;
using InvestmentOptionCalculator.Api.Models.Requests;
using InvestmentOptionCalculator.Api.Models.Responses.InvestmentOption;
using System.Collections.Generic;

namespace InvestmentOptionCalculator.Api.ModelMappers
{
    public interface IInvestmentOptionMapper
    {
        List<InvestmentOptionDto> FromCalculateROIRequestToInvestmentOptionDtos(CalculateROIRequest requestModel);
        InvestmentOptionCalculationResponse FromCalculationModelToInvestmentOptionCalculationResponse(CalculationModel calculationModel, string currencyCode);
    }
}