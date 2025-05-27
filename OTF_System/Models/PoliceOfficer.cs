using System.ComponentModel.DataAnnotations;

namespace OTF_System.Models
{
    public class PoliceOfficer:User
    {
        [Key]
        [StringLength(10)]
        public string PoliceID { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(500)]
        public string Username { get; set; }

        [Required]
        [StringLength(12)]
        public string NIC { get; set; }

        [StringLength(100)]
        public string PoliceStation { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
