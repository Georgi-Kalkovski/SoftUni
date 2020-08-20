using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class ImportCustomerTicketsDto
    {
        [XmlElement("FirstName")]
        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required, MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [XmlElement("Age")]
        [Required, Range(12, 110)]
        public int Age { get; set; }

        [XmlElement("Balance")]
        [Required, Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public TicketDto[] Tickets { get; set; }
    }
    [XmlType("Ticket")]
    public class TicketDto
    {

        [XmlElement("ProjectionId")]
        [Required]
        public int ProjectionId { get; set; }

        [XmlElement("Price")]
        [Required, Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
