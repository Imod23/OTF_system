using System;
using System.ComponentModel.DataAnnotations;

namespace OTF_System.Models
{
    public class Fine
    {
        [Key]
        public string FineID { get; set; }

        [Required]
        [StringLength(10)]
        public string VehicleNo { get; set; }

        [Required]
        [StringLength(10)]
        public string VehicleType { get; set; }

        [Required]
        [StringLength(20)]
        public string PoliceStation { get; set; }

        [Required]
        [StringLength(20)]
        public string Location { get; set; }

        [Required]
        [StringLength(40)]
        public string FineType { get; set; }

        [Required]
        public decimal FineAmount { get; set; } = 0.00m;

        public DateTime IssueDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(10)]
        public string LicenseNo { get; set; }

        [StringLength(50)]
        public string PinNumber { get; set; }

        [StringLength(12)]
        public string NIC { get; set; }
    }
}
