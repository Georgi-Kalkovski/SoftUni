using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Car")]
    public class CarsDto
    {
        [XmlElement("make")]
        public string Make { get; set; }
        [XmlElement("model")]
        public string Model { get; set; }
        [XmlElement("TraveledDistance")]
        public int TraveledDistance { get; set; }
        [XmlArray("parts")]
        public List<PartsId> CarParts { get; set; }
    }
    [XmlType("partId")]
    public class PartsId
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
