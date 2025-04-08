using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace KhodalKrupaERP.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; private set; }

        [Required]
        public string Name { get; set; }

        public DateTime? CreatedAt { get; private set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        //Navigation Property for Relationship(One Service can have multiple ChallanTransactions)
        public virtual ICollection<ChallanTransaction> ChallanTransactions { get; set; }

        // Constructor
        public Service(string name)
        {
            this.Name = name;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
            ChallanTransactions = new List<ChallanTransaction>();
        }

        // Empty Constructor for EF
        public Service() { }
    }
}