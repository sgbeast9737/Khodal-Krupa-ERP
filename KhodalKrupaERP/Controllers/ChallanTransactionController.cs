using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;

namespace KhodalKrupaERP.Controllers
{
    public class ChallanTransactionController
    {
        // ✅ Create a new ChallanTransaction
        public static void AddChallanTransaction(int challanId, int diamond, float rate, int paper)
        {
            using (var db = new AppDbContext())
            {
                var transaction = new ChallanTransaction(challanId, diamond, rate, paper);
                db.ChallanTransactions.Add(transaction);
                db.SaveChanges();
            }
        }

        public static BindingList<ChallanTransaction> GetAllChallanTransactions()
        {
            using (var db = new AppDbContext())
            {
                return new BindingList<ChallanTransaction>(db.ChallanTransactions.ToList());
            }
        }

        // ✅ Get all challanTransactions
        public static List<ChallanTransaction> GetAllchallanTransactions()
        {
            using (var db = new AppDbContext())
            {
                return db.ChallanTransactions.ToList();
            }
        }

        // ✅ Get a specific ChallanTransaction by ID
        public static ChallanTransaction GetChallanTransactionById(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.ChallanTransactions.Find(id);
            }
        }

        // ✅ Update a ChallanTransaction
        public static void UpdateChallanTransaction(int id, int diamond, float rate, int paper)
        {
            using (var db = new AppDbContext())
            {
                var transaction = db.ChallanTransactions.Find(id);
                if (transaction != null)
                {
                    transaction.Diamond = diamond;
                    transaction.Rate = rate;
                    transaction.Paper = paper;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"Challan Transaction not found of given id {id} for update process");
                }
            }
        }

        //Hybrid Approach – Pass Whole Object but Track Changes Manually

        //Only Updates Modified Fields – Prevents unnecessary database writes.
        //✔ No Need to Manually Pass Fields in Function Call – You pass the whole object, but only changed fields are updated.
        //✔ Scalable – Works well even if the Customer model has 20+ properties.

        public static void UpdateChallanTransaction(ChallanTransaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction), "Customer object cannot be null. error while updating record.");

            using (var db = new AppDbContext())
            {
                var existingTransaction = db.ChallanTransactions.Find(transaction.ChallanTransactionId);

                if (existingTransaction != null)
                {
                    // Update fields
                    if (existingTransaction.Diamond != transaction.Diamond)
                        existingTransaction.Diamond = transaction.Diamond;

                    if (existingTransaction.Rate != transaction.Rate)
                        existingTransaction.Rate = transaction.Rate;

                    if (existingTransaction.Paper != transaction.Paper)
                        existingTransaction.Paper = transaction.Paper;

                    existingTransaction.UpdatedAt = DateTime.UtcNow;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"Challan transaction with ID {transaction.ChallanTransactionId} not found. error while updating record.");
                }
            }
        }

        // ✅ Delete a ChallanTransaction
        public static void DeleteChallanTransaction(int id)
        {
            using (var db = new AppDbContext())
            {
                var transaction = db.ChallanTransactions.Find(id);
                if (transaction != null)
                {
                    db.ChallanTransactions.Remove(transaction);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"Challan transaction not found of given id {id} for delete process");
                }
            }
        }
    }
}