using System.Collections.Generic;

namespace RealEstates.Models
{
    public class Property
    {

        public Property()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public int Size { get; set; }

        public int? YardSize { get; set; }

        public byte? Floor { get; set; }

        public byte? TotalFloors { get; set; }

        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public int? Year { get; set; }

        public int PropertyTypeId { get; set; }

        public virtual PropertyType PropertyType { get; set; }

        public int BuildingTypeId { get; set; }

        public virtual BuildingType BuildingType { get; set; }

        /// <summary>
        /// Gets or Sets the property price in Euro
        /// </summary>
        public int Price { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
