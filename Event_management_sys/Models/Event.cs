using System.ComponentModel.DataAnnotations.Schema;

namespace Event_management_sys.Models
{
    public class Event
    {
        public int ID { get; set; } 

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public DateTime EventDate { get; set; }

        //public string Description { get; set; } = string.Empty;

        public int TotalSeats { get; set; }

        public int AvailableSeats { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TicketPrice { get; set; }   
    }
}
