using InvestmentOptionCalculator.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    public class CalculationStrategyFactory : ICalculationStrategyFactory
    {
        private readonly ICalculationStrategy _cashInvestmentsStrategy = new CashInvestmentsStrategy();
        private readonly ICalculationStrategy _fixedInterestStrategy = new FixedInterestStrategy();
        private readonly ICalculationStrategy _sharesStrategy = new SharesStrategy();
        private readonly ICalculationStrategy _managedFundsStrategy = new ManagedFundsStrategy();
        private readonly ICalculationStrategy _exchangeTradedFundsStrategy = new ExchangeTradedFundsStrategy();
        private readonly ICalculationStrategy _investmentBondsStrategy = new InvestmentBondsStrategy();
        private readonly ICalculationStrategy _annuitiesStrategy = new AnnuitiesStrategy();
        private readonly ICalculationStrategy _listedInvestmentCompaniesStrategy = new ListedInvestmentCompaniesStrategy();
        private readonly ICalculationStrategy _realEstateInvestmentTrustsStrategy = new RealEstateInvestmentTrustsStrategy();

        public ICalculationStrategy GetCalculationStrategy(Enums.InvestmentOption investmentOptions)
        {
            return investmentOptions switch
            {
                Enums.InvestmentOption.CashInvestments => _cashInvestmentsStrategy,
                Enums.InvestmentOption.FixedInterest => _fixedInterestStrategy,
                Enums.InvestmentOption.Shares => _sharesStrategy,
                Enums.InvestmentOption.ManagedFunds => _managedFundsStrategy,
                Enums.InvestmentOption.ExchangeTradedFunds => _exchangeTradedFundsStrategy,
                Enums.InvestmentOption.InvestmentBonds => _investmentBondsStrategy,
                Enums.InvestmentOption.Annuities => _annuitiesStrategy,
                Enums.InvestmentOption.ListedInvestmentCompanies => _listedInvestmentCompaniesStrategy,
                Enums.InvestmentOption.RealEstateInvestmentTrusts => _realEstateInvestmentTrustsStrategy,
                _ => null,
            };
        }
    }
}
