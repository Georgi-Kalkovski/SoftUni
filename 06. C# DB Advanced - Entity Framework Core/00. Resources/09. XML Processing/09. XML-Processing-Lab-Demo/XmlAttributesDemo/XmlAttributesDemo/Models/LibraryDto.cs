using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlAttributesDemo.Models
{
    [XmlRoot("Library")]
    [XmlType("Library")]
    public class LibraryDto
    {
        [XmlAttribute("Name")]
        public string LibraryName { get; set; }

        [XmlElement("Sections")]
        public SectionDto Sections { get; set; }

        [XmlIgnore]
        public decimal CardPrice { get; set; }
    }
}
