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
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } // Navigation Property

        [Required]
        public int DesignNo { get; set; }

        [Required]
        public DateTime ChallanDate { get; set; }

        public DateTime? createdAt { get; private set; } = DateTime.UtcNow;
        public DateTime? updatedAt { get; set; } = DateTime.UtcNow;

        // Constructor
        public Challan(int customerId, int designNo, DateTime challanDate)
        {
            this.CustomerId = customerId;
            this.DesignNo = designNo;
            this.ChallanDate = challanDate;
            this.createdAt = DateTime.UtcNow;
            this.updatedAt = DateTime.UtcNow;
        }

        // Empty Constructor for EF
        public Challan() { }

        // Call this method before saving updates
        public void UpdateTimestamp()
        {
            this.UpdatedAt = DateTime.UtcNow;
        }
    }
}
