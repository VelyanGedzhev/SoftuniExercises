using AutoMapper;
using RealEstates.Models;
using RealEstates.Services.Models;
using System.Linq;

namespace RealEstates.Services.Profiler
{
    public class RealEstateProfiler : Profile
    {
        public RealEstateProfiler()
        {
            this.CreateMap<Property, PropertyInfoDto>()
                .ForMember(x => x.BuildingType, y => y.MapFrom(s => s.BuildingType.Name));

            this.CreateMap<District, DistrictInfoDto>()
                .ForMember(x => x.AveragePricePerSqrMeter, 
                    y => y.MapFrom(s => s.Properties
                            .Where(p => p.Price.HasValue)
                            .Average(p => p.Price / (decimal)p.Size) ?? 0));

            this.CreateMap<Property, PropertyInfoFullDataDto>()
                .ForMember(x => x.BuildingType, y => y.MapFrom(s => s.BuildingType.Name))
                .ForMember(x => x.PropertyType, y => y.MapFrom(p => p.PropertyType.Name))
                .ForMember(x => x.District, y => y.MapFrom(d => d.District.Name));

            this.CreateMap<Tag, TagInfoDto>();
        }
    }
}