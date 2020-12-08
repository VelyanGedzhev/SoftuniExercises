namespace OnlineShop.Models.Products.Components
{
    public class Motherboard : Product
    {
        private const double multiplier = 1.25;

        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            
        }

        public override double OverallPerformance => base.OverallPerformance * multiplier;
    }
}
