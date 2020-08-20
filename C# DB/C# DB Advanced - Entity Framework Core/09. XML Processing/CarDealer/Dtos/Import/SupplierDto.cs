using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Supplier")]
    public class SupplierDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
