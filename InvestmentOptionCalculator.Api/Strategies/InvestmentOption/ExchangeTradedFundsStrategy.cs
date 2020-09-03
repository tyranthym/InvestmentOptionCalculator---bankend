namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    public class ExchangeTradedFundsStrategy : ICalculationStrategy
    {
        public decimal CalculateFee(decimal investmentPercentage, decimal roi)
        {
            return roi * 0.02M; // 2%
        }

        public decimal CalculateROI(decimal investmentPercentage, decimal investmentAmount)
        {
            if (investmentPercentage > 0 && investmentPercentage <= 0.4M)
            {
                return investmentAmount * 0.128M;  // 12.8%
            }
            else
            {
                return investmentAmount * 0.25M;  // 25%
            }
        }
    }
}