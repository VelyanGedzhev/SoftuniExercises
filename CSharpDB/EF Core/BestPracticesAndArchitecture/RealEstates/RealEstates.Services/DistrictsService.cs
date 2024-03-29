﻿using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using RealEstates.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.Services
{

    public class DistrictsService : BaseService, IDistrictsService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            var districts = dbContext.Districts
                .ProjectTo<DistrictInfoDto>(Mapper.ConfigurationProvider)
                //.Select(x => new DistrictInfoDto
                //{
                //    Name = x.Name,
                //    PropertiesCount = x.Properties.Count,
                //    AveragePricePerSqrMeter = x.Properties
                //            .Where(p => p.Price.HasValue)
                //            .Average(p => p.Price / (decimal)p.Size) ?? 0,
                //})
                .OrderByDescending(x => x.AveragePricePerSqrMeter)
                .Take(count)
                .ToList();

            return districts;
        }
    }
}
