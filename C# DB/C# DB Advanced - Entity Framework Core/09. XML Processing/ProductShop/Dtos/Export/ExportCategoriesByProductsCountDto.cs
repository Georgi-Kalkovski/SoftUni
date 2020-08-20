using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Category")]
    public class ExportCategoriesByProductsCountDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }
        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
