using KhodalKrupaERP.Models;
using System.Data.Entity;

namespace KhodalKrupaERP.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=SQLiteDbConnection")
        {
            this.Database.ExecuteSqlCommand("PRAGMA foreign_keys=ON;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Challan> Challans{ get; set; }
        public DbSet<ChallanTransaction> ChallanTransactions{ get; set; }
    }
}
