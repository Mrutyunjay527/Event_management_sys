namespace Event_management_sys.Models
{
    public class Booking
    {
        public int BookingID { get; set; }

        public int EventID { get; set; }

        public int NumberOfTickets { get; set; }

        public double TotalAmount {  get; set; }

        public DateTime BookingDate { get; set; }
    }
}
