using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace KhodalKrupaERP.Models
{
    public class ChallanTransaction
    {
        // Empty Constructor for EF
        public ChallanTransaction() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate ID
        public int ChallanTransactionId { get; private set; }

        // Foreign Key
        [ForeignKey("Challan")]
        public int ChallanId { get; set; }
        public virtual Challan Challan { get; set; } // Navigation Property

        public int Diamond { get; set; }
        public float Rate { get; set; }
        public int Paper { get; set; }

        public float Total { get; private set; } // Store total in DB

        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        // Constructor
        public ChallanTransaction(int challanId, int diamond, float rate, int paper)
        {
            this.ChallanId = challanId;
            this.Diamond = diamond;
            this.Rate = rate;
            this.Paper = paper;
            this.Total = CalculateTotal();
            this.UpdatedAt = DateTime.UtcNow;
        }

        private float CalculateTotal()
        {
            return Diamond * Rate + Paper;
        }

        // Call this method before saving updates
        public void UpdateValues(int diamond, float rate, int paper)
        {
            this.Diamond = diamond;
            this.Rate = rate;
            this.Paper = paper;
            this.Total = CalculateTotal();
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
