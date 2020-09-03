namespace InvestmentOptionCalculator.Api.Strategies.InvestmentOption
{
    internal class ListedInvestmentCompaniesStrategy : ICalculationStrategy
    {
        public decimal CalculateFee(decimal investmentPercentage, decimal roi)
        {
            return roi * 0.013M;  //1.3%
        }

        public decimal CalculateROI(decimal investmentPercentage, decimal investmentAmount)
        {
            return investmentAmount * 0.06M;  //6%
        }
    }
}