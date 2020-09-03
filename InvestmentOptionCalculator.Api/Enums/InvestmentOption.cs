using InvestmentOptionCalculator.Api.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Enums
{
    public enum InvestmentOption
    {
        [Display(Name = InvestmentOptionNames.CashInvestments)]
        CashInvestments,
        [Display(Name = InvestmentOptionNames.FixedInterest)]
        FixedInterest,
        [Display(Name = InvestmentOptionNames.Shares)]
        Shares,
        [Display(Name = InvestmentOptionNames.ManagedFunds)]
        ManagedFunds,
        [Display(Name = InvestmentOptionNames.ExchangeTradedFunds)]
        ExchangeTradedFunds,
        [Display(Name = InvestmentOptionNames.InvestmentBonds)]
        InvestmentBonds,
        [Display(Name = InvestmentOptionNames.Annuities)]
        Annuities,
        [Display(Name = InvestmentOptionNames.ListedInvestmentCompanies)]
        ListedInvestmentCompanies,
        [Display(Name = InvestmentOptionNames.RealEstateInvestmentTrusts)]
        RealEstateInvestmentTrusts
    }
}
