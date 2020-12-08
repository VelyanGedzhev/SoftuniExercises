namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Product
    {
        private const double multiplier = 1.05;
        public PowerSupply(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * multiplier;
    }
}
