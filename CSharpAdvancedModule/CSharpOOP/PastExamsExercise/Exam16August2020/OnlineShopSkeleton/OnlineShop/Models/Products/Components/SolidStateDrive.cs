using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    class SolidStateDrive : Product
    {
        private const double multiplier = 1.20;
        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
        }

        public override double OverallPerformance => base.OverallPerformance * multiplier;
    }
}
