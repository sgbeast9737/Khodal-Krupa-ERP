using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace KhodalKrupaERP.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string PhoneNo { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

        //Navigation Property for Relationship(One Customer can have multiple Challans)
        public virtual ICollection<Challan> Challans { get; set; }

        // Constructor
        public Customer(string name, string phoneNo)
        {
            Name = name;
            Phone_No = phoneNo;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            //Challans = new List<Challan>();
        }

        // Empty Constructor for EF
        public Customer() { }
    }
}