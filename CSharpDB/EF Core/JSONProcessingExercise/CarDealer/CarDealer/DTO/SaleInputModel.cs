using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class SaleInputModel
    {
        public int CardId { get; set; }

        public int CustomerId { get; set; }

        public int Discount { get; set; }
    }
}
