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
        public string DesignNo { get; set; }

        [Required]
        public DateTime ChallanDate { get; set; }

        public DateTime? CreatedAt { get; private set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ChallanTransaction> ChallanTransactions { get; set; }

        // Constructor
        public Challan(int customerId, string designNo, DateTime challanDate)
        {
            this.CustomerId = customerId;
            this.DesignNo = designNo;
            this.ChallanDate = challanDate;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            this.ChallanTransactions = new List<ChallanTransaction>();
        }

        // Empty Constructor for EF
        public Challan() { }
    }
}
