using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Models.Responses.InvestmentOption
{
    public class InvestmentOptionCalculationResponse
    {
        public string CurrencyCode { get; set; }    //e.g. AUD or USD
        public decimal TotalROI { get; set; }       
        public decimal TotalFee { get; set; }
    }
}
