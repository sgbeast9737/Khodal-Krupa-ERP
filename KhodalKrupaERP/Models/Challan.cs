using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace KhodalKrupaERP.Models
{
    public class Challan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChallanId { get; private set; }

        // Foreign Key
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime ChallanDate { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ChallanTransaction> ChallanTransactions { get; set; }

        // Constructor
        public Challan(int customerId, DateTime challanDate)
        {
            this.CustomerId = customerId;
            this.ChallanDate = challanDate;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.ChallanTransactions = new List<ChallanTransaction>();
        }

        // Empty Constructor for EF
        public Challan() { }
    }
}
