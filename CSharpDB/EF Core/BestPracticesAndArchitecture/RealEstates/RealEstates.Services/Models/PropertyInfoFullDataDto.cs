using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services.Models
{
    public class PropertyInfoFullDataDto
    {
        public int Id { get; set; }

        public string District { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public int Year { get; set; }

        public string PropertyType { get; set; }

        public string BuildingType { get; set; }

        public IEnumerable<TagInfoDto> Tags { get; set; }
    }
}
