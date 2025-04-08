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
            using (var db = new AppDbContext())
            {
                var challan = db.Challans.Find(id);
                if (challan != null)
                {
                    db.Challans.Remove(challan);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"challan not found of given id {id} for delete process");
                }
            }
        }

        public static List<ChallanInfo> GetInfoOfAllChallans()
        {
            using (var context = new AppDbContext())
            {
                return context.Database.SqlQuery<ChallanInfo>(
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

        #region less_used_methods

        // ✅ Create a new Challan
        public static void AddChallan(DateTime challanDate, string designNo, int customerId)
        {
            using (var db = new AppDbContext())
            {
                var challan = new Challan(customerId, challanDate);
                db.Challans.Add(challan);
                db.SaveChanges();
            }
        }
   
        // ✅ Update a Challan
        public static void UpdateChallan(int id, int newCustomerId, DateTime newChallanDate)
        {
            using (var db = new AppDbContext())
            {
                var challan = db.Challans.Find(id);
                if (challan != null)
                {
                    challan.CustomerId = newCustomerId;
                    challan.ChallanDate = newChallanDate;
                    challan.UpdatedAt = DateTime.Now; // Update the timestamp
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"challan not found of given id {id} for update process");
                }
            }
        }

        //Hybrid Approach – Pass Whole Object but Track Changes Manually

        //Only Updates Modified Fields – Prevents unnecessary database writes.
        //✔ No Need to Manually Pass Fields in Function Call – You pass the whole object, but only changed fields are updated.
        //✔ Scalable – Works well even if the Customer model has 20+ properties.

        public static void UpdateChallan(Challan challan)
        {
            if (challan == null)
                throw new ArgumentNullException(nameof(challan), "Challan object cannot be null. error while updating record.");

            using (var db = new AppDbContext())
            {
                var existingChallan = db.Challans.Find(challan.ChallanId);

                if (existingChallan != null)
                {
                    // Update fields

                    if (existingChallan.CustomerId != challan.CustomerId)
                        existingChallan.CustomerId = challan.CustomerId;

                    if (existingChallan.ChallanDate != challan.ChallanDate)
                        existingChallan.ChallanDate = challan.ChallanDate;

                    existingChallan.UpdatedAt = DateTime.Now;

                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"Challan with ID {challan.ChallanId} not found. error while updating record.");
                }
            }
        }

        #endregion less_used_methods
    }
}