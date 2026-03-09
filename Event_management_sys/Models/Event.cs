namespace Event_management_sys.Models
{
    public class Event
    {
        public int ID { get; set; } 

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public DateTime EventDate { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
