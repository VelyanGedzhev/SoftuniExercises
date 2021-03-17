using AutoMapper;
using CarDealer.DataTransferObjects.Input;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<CustomerInputModel, Customer>();
        }
    }
}
