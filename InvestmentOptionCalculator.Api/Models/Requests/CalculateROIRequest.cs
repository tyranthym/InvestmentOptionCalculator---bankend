using InvestmentOptionCalculator.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Models.Requests
{
    public class CalculateROIRequest
    {
        public decimal TotalAmount { get; set; }

        public List<CalculateOptionRequest> Options { get; set; }
    }
}
