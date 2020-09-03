namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    public class FixedInterestStrategy : ICalculationStrategy
    {
        public decimal CalculateFee(decimal investmentPercentage, decimal roi)
        {
            return roi * 0.01M;  //1%
        }

        public decimal CalculateROI(decimal investmentPercentage, decimal investmentAmount)
        {
            return investmentAmount * 0.1M;  //10%
        }
    }
}