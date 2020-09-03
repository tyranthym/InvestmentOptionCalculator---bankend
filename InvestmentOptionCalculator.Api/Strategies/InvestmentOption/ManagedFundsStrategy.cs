namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    internal class ManagedFundsStrategy : ICalculationStrategy
    {
        public decimal CalculateFee(decimal investmentPercentage, decimal roi)
        {
            return roi * 0.003M;   //.3%
        }

        public decimal CalculateROI(decimal investmentPercentage, decimal investmentAmount)
        {
            return investmentAmount * 0.12M;  //12%
        }
    }
}