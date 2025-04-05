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

        // THIS IS WHERE YOU ADD THE CONFIGURATION
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChallanTransaction>()
                .HasRequired(c => c.Challan)
                .WithMany(p => p.ChallanTransactions)
                .HasForeignKey(c => c.ChallanId)
                .WillCascadeOnDelete(true); // ✅ Enables cascade delete

            base.OnModelCreating(modelBuilder);
        }
    }
}
