using KhodalKrupaERP.Models;
using System.Data.Entity;

namespace KhodalKrupaERP.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=SQLiteDbConnection") { }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Challan> challans{ get; set; }
        public DbSet<ChallanTransaction> challanTransactions{ get; set; }
    }
}
