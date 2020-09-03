using FluentValidation;
using InvestmentOptionCalculator.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Models.Requests
{
    public class CalculateOptionRequest
    {
        public InvestmentOption InvestmentOption { get; set; }
        public decimal InvestmentPercentage { get; set; }        
    }

    //fluent validation validatior
    public class CalculateOptionRequestValidator : AbstractValidator<CalculateOptionRequest>
    {
        public CalculateOptionRequestValidator()
        {
            RuleFor(model => model.InvestmentOption).IsInEnum();
            RuleFor(model => model.InvestmentPercentage).GreaterThanOrEqualTo(0.0M).LessThanOrEqualTo(100.0M);
        }
    }
}
