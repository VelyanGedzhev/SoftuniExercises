using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RealEstates.Services.Models
{
    [XmlType("Property")]
    public class PropertyInfoFullDataDto
    {
        [XmlElement("propertyId")]
        public int Id { get; set; }

        [XmlElement("propertyDistrict")]
        public string District { get; set; }

        [XmlElement("propertySize")]
        public int Size { get; set; }

        [XmlElement("propertyPrice")]
        public int Price { get; set; }

        [XmlElement("propertyYear")]
        public int Year { get; set; }

        [XmlElement("propertyType")]
        public string PropertyType { get; set; }

        [XmlElement("buildingType")]
        public string BuildingType { get; set; }

        [XmlArray("tags")]
        public TagInfoDto[] Tags { get; set; }
    }
}
