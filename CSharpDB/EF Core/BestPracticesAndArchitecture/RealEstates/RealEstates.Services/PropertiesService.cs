using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.Services
{
    public class PropertiesService : BaseService, IPropertiesService
    {
        private readonly ApplicationDbContext dbContext;
        public PropertiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Add(string districtName, int floor, 
            int maxFloor, int size, int yardSize, 
            int year, string propertyType, string buildingType, int price)
        {
            var property = new Property
            {
                Size = size,
                Price = price <= 0 ? null : price,
                Floor = floor <= 0  || floor > 255 ? null : (byte)floor,
                TotalFloors = maxFloor <= 0 || maxFloor > 255 ? null : (byte)maxFloor,
                YardSize = yardSize <= 0 ? null : yardSize,
                Year = year <= 1800 ? null : year,
            };

            var dbDistrict = dbContext.Districts.FirstOrDefault(x => x.Name == districtName);

            if (dbDistrict == null)
            {
                dbDistrict = new District { Name = districtName};
            }

            property.District = dbDistrict;

            var dbPropertyType = dbContext.PropertyTypes.FirstOrDefault(x => x.Name == propertyType);

            if (dbPropertyType == null)
            {
                dbPropertyType = new PropertyType { Name = propertyType};
            }

            property.PropertyType = dbPropertyType;

            var dbBuildingType = dbContext.BuildingTypes.FirstOrDefault(x => x.Name == buildingType);

            if (dbBuildingType == null)
            {
                dbBuildingType = new BuildingType { Name = buildingType};
            }

            property.BuildingType = dbBuildingType;

            dbContext.Properties.Add(property);
            dbContext.SaveChanges();
        }

        public decimal AveragePricePerSquareMeter()
        {
            var properties = dbContext.Properties
                .Where(x => x.Price.HasValue)
                .Average(x => x.Price / (decimal)x.Size) ?? 0;

            return properties;
        }

        public decimal AveragePricePerSquareMeter(int districtId)
        {
            var properties = dbContext.Properties
                .Where(x => x.Price.HasValue && x.District.Id == districtId)
                .Average(x => x.Price / (decimal)x.Size) ?? 0;

            return properties;
        }

        public double AverageSize(int districtId)
        {
            var averageSize = dbContext.Properties
                .Where(x => x.DistrictId == districtId)
                .Average(x => x.Size);

            return averageSize;
        }

        public IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize)
        {
            var properties = dbContext.Properties
                .Where(x => x.Price >= minPrice 
                        && x.Price <= maxPrice 
                        && x.Size >= minSize 
                        && x.Size <= maxSize)
                .ProjectTo<PropertyInfoDto>(Mapper.ConfigurationProvider)
                .ToList();

            return properties;
        }

        public IEnumerable<PropertyInfoFullDataDto> GetFullData(int count)
        {
            var properties = dbContext.Properties
                .Where(x => x.Floor.HasValue
                && x.Floor.Value > 1 && x.Floor.Value <= 8
                && x.Year.HasValue )
                .ProjectTo<PropertyInfoFullDataDto>(Mapper.ConfigurationProvider)
                .OrderByDescending(x => x.Price)
                .ThenByDescending(x => x.Size)
                .ThenByDescending(x => x.Year)
                .Take(count)
                .ToList();

            return properties;
        }
    }
}
