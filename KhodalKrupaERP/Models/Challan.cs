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
        public int DesignNo { get; set; }

        [Required]
        public DateTime ChallanDate { get; set; }

        public DateTime? CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ChallanTransaction> ChallanTransactions { get; set; }

        // Constructor
        public Challan(int customerId, int designNo, DateTime challanDate)
        {
            this.CustomerId = customerId;
            this.DesignNo = designNo;
            this.ChallanDate = challanDate;
            this.CreatedAt = DateTime.UtcNow;
            this.UpdatedAt = DateTime.UtcNow;
            this.ChallanTransactions = new List<ChallanTransaction>();
        }

        // Empty Constructor for EF
        public Challan() { }
    }
}
