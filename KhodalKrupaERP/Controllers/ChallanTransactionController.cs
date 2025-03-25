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
        public void AddChallanTransaction(int challanId, int diamond, float rate, int paper)
        {
            using (var db = new AppDbContext())
            {
                var transaction = new ChallanTransaction(challanId, diamond, rate, paper);
                db.ChallanTransactions.Add(transaction);
                db.SaveChanges();
                Console.WriteLine("Challan transaction added successfully!");
            }
        }

        public BindingList<ChallanTransaction> GetAllChallanTransactions()
        {
            using (var db = new AppDbContext())
            {
                return new BindingList<ChallanTransaction>(db.ChallanTransactions.ToList());
            }
        }

        // ✅ Get all challanTransactions
        public List<ChallanTransaction> GetAllchallanTransactions()
        {
            using (var db = new AppDbContext())
            {
                return db.ChallanTransactions.ToList();
            }
        }

        // ✅ Get a specific ChallanTransaction by ID
        public ChallanTransaction GetChallanTransactionById(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.ChallanTransactions.Find(id);
            }
        }

        // ✅ Update a ChallanTransaction
        public void UpdateChallanTransaction(int id, int diamond, float rate, int paper)
        {
            using (var db = new AppDbContext())
            {
                var transaction = db.ChallanTransactions.Find(id);
                if (transaction != null)
                {
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
                var transaction = db.ChallanTransactions.Find(id);
                if (transaction != null)
                {
                    db.ChallanTransactions.Remove(transaction);
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