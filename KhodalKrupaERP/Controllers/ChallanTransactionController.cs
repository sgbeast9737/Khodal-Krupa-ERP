using System;
using System.Collections.Generic;
using System.Linq;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;

namespace KhodalKrupaERP.Controllers
{
    public class ChallanTransactionController
    {
        // ✅ Create a new ChallanTransaction
        public void AddChallanTransaction(int challanId, int diamond, float rate, int paper)
        {
            using (var db = new AppDbContext())
            {
                var transaction = new ChallanTransaction(challanId, diamond, rate, paper);
                db.challanTransactions.Add(transaction);
                db.SaveChanges();
                Console.WriteLine("Challan transaction added successfully!");
            }
        }

        // ✅ Get all challanTransactions
        public List<ChallanTransaction> GetAllchallanTransactions()
        {
            using (var db = new AppDbContext())
            {
                return db.challanTransactions.ToList();
            }
        }

        // ✅ Get a specific ChallanTransaction by ID
        public ChallanTransaction GetChallanTransactionById(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.challanTransactions.Find(id);
            }
        }

        // ✅ Update a ChallanTransaction
        public void UpdateChallanTransaction(int id, int diamond, float rate, int paper)
        {
            using (var db = new AppDbContext())
            {
                var transaction = db.challanTransactions.Find(id);
                if (transaction != null)
                {
                    transaction.UpdateValues(diamond, rate, paper);
                    db.SaveChanges();
                    Console.WriteLine("Challan transaction updated successfully!");
                }
                else
                {
                    Console.WriteLine("Challan transaction not found!");
                }
            }
        }

        // ✅ Delete a ChallanTransaction
        public void DeleteChallanTransaction(int id)
        {
            using (var db = new AppDbContext())
            {
                var transaction = db.challanTransactions.Find(id);
                if (transaction != null)
                {
                    db.challanTransactions.Remove(transaction);
                    db.SaveChanges();
                    Console.WriteLine("Challan transaction deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Challan transaction not found!");
                }
            }
        }
    }
}