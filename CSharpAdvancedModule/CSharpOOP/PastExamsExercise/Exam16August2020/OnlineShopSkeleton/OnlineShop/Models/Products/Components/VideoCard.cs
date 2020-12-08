namespace OnlineShop.Models.Products.Components
{
    public class VideoCard : Product
    {

        private const double multiplier = 1.15;
        public VideoCard(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * multiplier;
    }
}
