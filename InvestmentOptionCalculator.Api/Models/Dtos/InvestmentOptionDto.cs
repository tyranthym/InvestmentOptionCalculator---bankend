using InvestmentOptionCalculator.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Models.Dtos
{
    public class InvestmentOptionDto
    {
        public InvestmentOption InvestmentOption { get; set; }
        public decimal InvestmentPercentage { get; set; }
        public decimal InvestmentAmount { get; set; }    // total amount * InvestmentPercentage
    }
}
