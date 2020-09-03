namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    public class SharesStrategy : ICalculationStrategy
    {
        public decimal CalculateFee(decimal investmentPercentage, decimal roi)
        {
            return roi * 0.025M;
        }

        public decimal CalculateROI(decimal investmentPercentage, decimal investmentAmount)
        {
            if (investmentPercentage >= 0 && investmentPercentage <= 0.7M)
            {
                return investmentAmount * 0.043M;  //4.3%
            }
            else
            {
                return investmentAmount * 0.06M;  //6%
            }
        }
    }
}