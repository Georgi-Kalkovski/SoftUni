using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class ExportOldestBooksDto
    {
        [XmlAttribute("Pages")]
        public int Pages { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }
    }
}
