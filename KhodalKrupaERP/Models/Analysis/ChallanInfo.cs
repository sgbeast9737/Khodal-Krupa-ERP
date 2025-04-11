using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhodalKrupaERP.Models.Analysis
{
    public class ChallanInfo
    {
        public int ChallanId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string DesignNo { get; set; }
        public DateTime ChallanDate { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public double? Total { get; set; }
        public string PhoneNo { get; set; }
    }
}
