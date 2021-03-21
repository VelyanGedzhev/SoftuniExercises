using RealEstates.Data;
using RealEstates.Models;
using System;
using System.Linq;

namespace RealEstates.Services
{
    public class TagService : BaseService, ITagService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPropertiesService propertiesService;

        public TagService(ApplicationDbContext dbContext, IPropertiesService propertiesService)
        {
            this.dbContext = dbContext;
            this.propertiesService = propertiesService;
        }


        public void Add(string name, int? importance = null)
        {
            var tag = new Tag
            {
                Name = name,
                Importance = importance,
            };

            this.dbContext.Tags.Add(tag);
            this.dbContext.SaveChanges();
        }

        public void BulkTagToPropertiesRelation()
        {
            var allProperties = dbContext.Properties.ToList();

            foreach (var prop in allProperties)
            {
                var averagePriceForDistrict = this.propertiesService.AveragePricePerSquareMeter(prop.DistrictId);

                if (prop.Price >= averagePriceForDistrict)
                {
                    Tag tag = GetTag("скъп-имот");
                    prop.Tags.Add(tag);
                }
                else if (prop.Price < averagePriceForDistrict)
                {
                    Tag tag = GetTag("евтин-имот");
                    prop.Tags.Add(tag);
                }

                var currentDate = DateTime.Now.AddDays(-10);

                if (prop.Year.HasValue && prop.Year <= currentDate.Year)
                {
                    Tag tag = GetTag("стар-имот");
                    prop.Tags.Add(tag);
                }
                else if (prop.Year.HasValue && prop.Year > currentDate.Year)
                {
                    Tag tag = GetTag("нов-имот");
                    prop.Tags.Add(tag);
                }

                var averagePropertySize = propertiesService.AverageSize(prop.DistrictId);

                if (prop.Size <= averagePropertySize)
                {
                    Tag tag = GetTag("малък-имот");
                    prop.Tags.Add(tag);
                }
                else if (prop.Size > averagePropertySize)
                {
                    Tag tag = GetTag("голям-имот");
                    prop.Tags.Add(tag);
                }

                if (prop.Floor.HasValue 
                    && prop.Floor.Value == 1)
                {
                    Tag tag = GetTag("първи-етаж");
                    prop.Tags.Add(tag);
                }
                else if (prop.Floor.HasValue 
                    && prop.TotalFloors.HasValue 
                    && prop.Floor.Value == prop.TotalFloors.Value)
                {
                    Tag tag = GetTag("последен-етаж");
                    prop.Tags.Add(tag);
                }
            }

            dbContext.SaveChanges();
        }

        private Tag GetTag(string tagName)
        {
            return dbContext.Tags.FirstOrDefault(x => x.Name == tagName);
        }
    }
}
