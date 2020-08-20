namespace Cinema.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Projection")]
    public class ImportProjectionDto
    {
        [XmlElement("MovieId")]
        public int MovieId { get; set; }

        [XmlElement("HallId")]
        public int HallId { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }
    }
}
