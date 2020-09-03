namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    public class RealEstateInvestmentTrustsStrategy : ICalculationStrategy
    {
        public decimal CalculateFee(decimal investmentPercentage, decimal roi)
        {
            return roi * 0.02M;  //2%
        }

        public decimal CalculateROI(decimal investmentPercentage, decimal investmentAmount)
        {
            return investmentAmount * 0.04M;  //4%
        }
    }
}