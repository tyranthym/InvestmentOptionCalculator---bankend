namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    internal class AnnuitiesStrategy : ICalculationStrategy
    {
        public decimal CalculateFee(decimal investmentPercentage, decimal roi)
        {
            return roi * 0.014M;  //1.4%
        }

        public decimal CalculateROI(decimal investmentPercentage, decimal investmentAmount)
        {
            return investmentAmount * 0.04M;  //4%
        }
    }
}