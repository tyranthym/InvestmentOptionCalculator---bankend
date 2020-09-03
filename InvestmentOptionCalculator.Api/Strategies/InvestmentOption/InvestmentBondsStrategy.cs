namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    internal class InvestmentBondsStrategy : ICalculationStrategy
    {
        public decimal CalculateFee(decimal investmentPercentage, decimal roi)
        {
            return roi * 0.009M;  //.9%
        }

        public decimal CalculateROI(decimal investmentPercentage, decimal investmentAmount)
        {
            return investmentAmount * 0.08M;  //8%
        }
    }
}