using System;
using System.Collections.Generic;
using System.Linq;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;
using KhodalKrupaERP.Models.Analysis;

namespace KhodalKrupaERP.Controllers
{
    public class ChallanTransactionController
    {
        // ✅ Create a new ChallanTransaction
        public static void AddChallanTransaction(AppDbContext context,int challanId, string designNo, int serviceId, int diamond, double rate, int paper)
        {
            var transaction = new ChallanTransaction(challanId, designNo, serviceId, diamond, rate, paper);
            context.ChallanTransactions.Add(transaction);
            context.SaveChanges();
        }       

        public static void UpdateChallanTransaction(AppDbContext context, ChallanTransaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction), "Challan transaction object cannot be null. error while updating record.");

            var existingTransaction = context.ChallanTransactions.Find(transaction.ChallanTransactionId);

            if (existingTransaction != null)
            {
                // Update fields
                if (existingTransaction.Diamond != transaction.Diamond)
                    existingTransaction.Diamond = transaction.Diamond;

                if (existingTransaction.Rate != transaction.Rate)
                    existingTransaction.Rate = transaction.Rate;

                if (existingTransaction.Paper != transaction.Paper)
                    existingTransaction.Paper = transaction.Paper;

                existingTransaction.UpdatedAt = DateTime.Now;
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Challan transaction with ID {transaction.ChallanTransactionId} not found. error while updating record.");
            }
        }

        public static void DeleteChallanTransaction(AppDbContext context, int id)
        {
            var transaction = context.ChallanTransactions.Find(id);
            if (transaction != null)
            {
                context.ChallanTransactions.Remove(transaction);
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Challan transaction not found of given id {id} for delete process");
            }
        }

        // ✅ Get all challanTransactions
        public static List<ChallanTransaction> GetAllChallanTransactions()
        {
            using (var db = new AppDbContext())
            {
                return db.ChallanTransactions.ToList();
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

        public static List<ChallanTransactionInfo> GetInfoOfAllChallanTransactions(int? customerId = null, DateTime? fromDate = null,DateTime? toDate = null)
        {
            
            using (var context = new AppDbContext())
            {

                return context.Database.SqlQuery<ChallanTransactionInfo>(
                     $@"SELECT 
	                    cus.CustomerId,
	                    cus.Name AS CustomerName,
	                    trans.DesignNo,
	                    c.ChallanDate,
	                    CAST(strftime('%m', c.ChallanDate) AS INTEGER) AS Month,  
	                    CAST(strftime('%Y', c.ChallanDate) AS INTEGER) AS Year, 
	                    trans.*
                    FROM
	                    ChallanTransactions trans
	                    LEFT JOIN Challans c ON c.ChallanId = trans.ChallanId
	                    LEFT JOIN Customers cus ON c.CustomerId = cus.CustomerId
                    WHERE
                        1 = 1
	                    {(customerId == null ? "" : "AND c.CustomerId = " + customerId)} 
                        {(fromDate == null || toDate == null ? "" : $"AND Date(c.ChallanDate) BETWEEN '{fromDate.Value.ToString("yyyy-MM-dd")}' AND '{toDate.Value.ToString("yyyy-MM-dd")}'")} 
                    ORDER BY c.ChallanDate DESC"
                 ).ToList();
            }
        }
    }
}