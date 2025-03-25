using KhodalKrupaERP.Models;
using System.Data.Entity;

namespace KhodalKrupaERP.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=SQLiteDbConnection") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Challan> Challans{ get; set; }
        public DbSet<ChallanTransaction> ChallanTransactions{ get; set; }
    }
}
