using CarDealer.DataTransferObjects.Output;
using System.Xml.Serialization;

namespace CarDealer
{
    [XmlType("car")]
    public class CarSaleOutputModel
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}