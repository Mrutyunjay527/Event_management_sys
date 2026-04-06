using System.ComponentModel.DataAnnotations;

namespace Event_management_sys.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";

        public string Role { get; set; } = "User"; // default
    }
}