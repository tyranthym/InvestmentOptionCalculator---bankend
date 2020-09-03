using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestmentOptionCalculator.Api.Constants;
using InvestmentOptionCalculator.Api.Extensions;
using InvestmentOptionCalculator.Api.Libs.CurrencyRate;
using InvestmentOptionCalculator.Api.ModelMappers;
using InvestmentOptionCalculator.Api.Models.BusinessLogic.InvestmentOption;
using InvestmentOptionCalculator.Api.Models.Requests;
using InvestmentOptionCalculator.Api.Models.Responses.InvestmentOption;
using InvestmentOptionCalculator.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentOptionCalculator.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentOptionsController : ControllerBase
    {
        private readonly ICurrencyConversionService _currencyConversionService;
        private readonly IInvestmentOptionService _investmentOptionService;
        private readonly IInvestmentOptionMapper _investmentOptionMapper;

        public InvestmentOptionsController(
            ICurrencyConversionService currencyConversionService,
            IInvestmentOptionService investmentOptionService,
            IInvestmentOptionMapper investmentOptionMapper)
        {
            this._currencyConversionService = currencyConversionService;
            this._investmentOptionService = investmentOptionService;
            this._investmentOptionMapper = investmentOptionMapper;
        }


        /// <summary>
        /// Get all investment options
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(InvestmentOptionGetAllResponse), 200)]
        public IActionResult GetAll()
        {
            List<string> investmentOptions = typeof(InvestmentOptionNames).GetAllPublicConstantValues<string>();
            var investmentOptionGetAllResponse = new InvestmentOptionGetAllResponse
            {
                InvestmentOptions = investmentOptions
            };
            return Ok(investmentOptionGetAllResponse);
        }

        [HttpPost("calculator")]
        [ProducesResponseType(typeof(InvestmentOptionCalculationResponse), 200)]
        public async Task<IActionResult> CalculateROIAndFee(CalculateROIRequest requestModel)
        {
            //map request to list of dtos
            var dtos = _investmentOptionMapper.FromCalculateROIRequestToInvestmentOptionDtos(requestModel);

            //calculate result
            CalculationModel calculationModel = _investmentOptionService.CalculateTotalROIAndFee(requestModel.TotalAmount, dtos);

            //get exchange rate from 3rd-party api
            double rate = await _currencyConversionService.GetAUDToUSDRate();

            //get final result 
            _investmentOptionService.CovertTotalROIAndFee(calculationModel, rate);

            //map to response
            var investmentOptionCalculationResponse = _investmentOptionMapper.FromCalculationModelToInvestmentOptionCalculationResponse(calculationModel, "USD");

            return Ok(investmentOptionCalculationResponse);
        }
    }
}
