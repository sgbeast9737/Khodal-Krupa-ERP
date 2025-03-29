using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhodalKrupaERP.Models
{
    public class ChallanInfo
    {
        public int ChallanId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNo { get; set; }
        public int DesignNo { get; set; }
        public DateTime ChallanDate { get; set; }
        public float TotalPaid { get; set; }
    }
}
