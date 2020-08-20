
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class ExportUserPurchasesDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }
        [XmlArray("Purchases")]
        public List<PurchasesDto> Purchases { get; set; }
        [XmlElement("TotalSpent")]
        public decimal TotalMoneySpent { get; set; }
    }

    [XmlType("Purchase")]
    public class PurchasesDto
    {
        [XmlElement("Card")]
        public string Card { get; set; }
        [XmlElement("Cvc")]
        public string Cvc { get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }
        [XmlElement("Game")]
        public GameDto Game { get; set; }
    }

    [XmlType("Game")]
    public class GameDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlElement("Genre")]
        public string Genre { get; set; }
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}