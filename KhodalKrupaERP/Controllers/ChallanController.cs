using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models.Analysis;
using KhodalKrupaERP.Models;

namespace KhodalKrupaERP.Controllers
{
    public class ChallanController
    {
        // ✅ Get a specific Challan by ID
        public static Challan GetChallanById(int id)
        {
            using (var db = new AppDbContext())
            {
                Challan challan = db.Challans.Find(id);
                var transactions = challan.ChallanTransactions;

                return challan;
            }
        }

        // ✅ Create a new Challan
        public static int AddChallan(AppDbContext context, int customerId, DateTime challanDate)
        {
            var challan = new Challan(customerId, challanDate);
            context.Challans.Add(challan);
            context.SaveChanges();

            return challan.ChallanId;
        }

        // ✅ Update a Challan
        public static void UpdateChallan(AppDbContext context, int id, int newCustomerId, DateTime newChallanDate)
        {
            var challan = context.Challans.Find(id);
            if (challan != null)
            {
                challan.CustomerId = newCustomerId;
                challan.ChallanDate = newChallanDate;
                challan.UpdatedAt = DateTime.Now; // Update the timestamp
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"challan not found of given id {id} for update process");
            }
        }

        // ✅ Delete a Challan
        public static void DeleteChallan(int id)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var challan = context.Challans.Find(id);
                        if (challan != null)
                        {
                            var transIds = (from challanTrans in challan.ChallanTransactions select challanTrans.ChallanTransactionId).ToList();

                            foreach (int transId in transIds)
                            {
                                ChallanTransactionController.DeleteChallanTransaction(context,transId);
                            }

                            context.Challans.Remove(challan);
                            context.SaveChanges();

                            transaction.Commit();
                        }
                        else
                        {
                            throw new Exception($"challan not found of given id {id} for delete process");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<ChallanInfo> GetInfoOfAllChallans()
        {
            using (var context = new AppDbContext())
            {
                List<ChallanInfo> challanInfos = context.Database.SqlQuery<ChallanInfo>(
                     @"SELECT
                      c.ChallanId,
                      trans.DesignNo,
                      c.ChallanDate,
                      CAST(strftime('%Y%m', c.ChallanDate) AS INTEGER) AS Month,  
                      CAST(strftime('%Y', c.ChallanDate) AS INTEGER) AS Year,   
                      cus.CustomerId,
                      cus.PhoneNo,
                      cus.Name AS CustomerName,
                      COALESCE(SUM(trans.Total), 0) AS Total
                    FROM
                      Challans c
                      LEFT JOIN Customers cus ON c.CustomerId = cus.CustomerId
                      LEFT JOIN ChallanTransactions trans ON c.ChallanId = trans.ChallanId
                    GROUP BY
                      c.ChallanId
                    ORDER BY c.ChallanDate desc"
                 ).ToList();

                return challanInfos;
            }
        }

        // ✅ Get all bindable challans
        public static BindingList<Challan> GetAllBindableChallans()
        {
            using (var db = new AppDbContext())
            {
                return new BindingList<Challan>(db.Challans.ToList());
            }
        }

        // ✅ Get all challans
        public static List<Challan> GetAllchallans()
        {
            using (var db = new AppDbContext())
            {
                return db.Challans.ToList();
            }
        }
    }
}