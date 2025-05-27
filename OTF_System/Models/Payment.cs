using System;
using System.ComponentModel.DataAnnotations;

namespace OTF_System.Models
{
    public class Payment
    {
        [Key]
        public string PaymentID { get; set; }

        [Required]
        public string FineID { get; set; }

        public DateTime? ExpireDate { get; set; }

        [StringLength(3)]
        public string CVC { get; set; }

        [StringLength(16)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(500)]
        public string CardholderName { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [StringLength(100)]
        public string PaymentMethod { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        public int ReceiptNumber { get; set; }
    }
}
