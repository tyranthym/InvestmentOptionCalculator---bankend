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
}
