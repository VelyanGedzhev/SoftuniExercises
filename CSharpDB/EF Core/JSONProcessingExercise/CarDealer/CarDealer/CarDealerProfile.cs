using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Customer, CustomerSalesDto>()
              .ForMember(x => x.Name, y => y.MapFrom(s => s.Name))
              .ForMember(x => x.CarsBought, y => y.MapFrom(s => s.Sales.Count))
              .ForMember(x => x.SpentMoney, y => y.MapFrom(s => s.Sales
                    .Select(c => c.Car
                                  .PartCars
                                  .Select(pc => pc.Part)
                                  .Sum(pc => pc.Price))
                    .Sum()));

            this.CreateMap<PartInputModel, Part>();
            this.CreateMap<CustomerInputModel, Customer>();
            this.CreateMap<SaleInputModel, Sale>();
        }
    }
}
