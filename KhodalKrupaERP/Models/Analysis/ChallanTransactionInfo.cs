using System;

namespace KhodalKrupaERP.Models.Analysis
{
    public class ChallanTransactionInfo
    {
        public int CustomerId { get; set; }
        public string DesignNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime? ChallanDate { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int ChallanTransactionId { get; set; }
        public int ChallanId { get; set; }
        public int Diamond { get; set; }
        public double Rate { get; set; }
        public int Paper { get; set; }
        public double Total { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}