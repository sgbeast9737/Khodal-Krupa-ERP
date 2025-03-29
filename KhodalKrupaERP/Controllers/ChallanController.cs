using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;

namespace KhodalKrupaERP.Controllers
{
    public class ChallanController
    {
        // ✅ Create a new Challan
        public static void AddChallan(DateTime challanDate, int designNo, int customerId)
        {
            using (var db = new AppDbContext())
            {
                var challan = new Challan(customerId, designNo, challanDate);
                db.Challans.Add(challan);
                db.SaveChanges();
            }
        }

        // ✅ Get all bindable challans
        public static BindingList<Challan> GetAllBindableCustomers()
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

        // ✅ Get a specific Challan by ID
        public static Challan GetChallanById(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Challans.Find(id);
            }
        }

        // ✅ Update a Challan
        public static void UpdateChallan(int id, int newCustomerId, int newDesignNo, DateTime newChallanDate)
        {
            using (var db = new AppDbContext())
            {
                var challan = db.Challans.Find(id);
                if (challan != null)
                {
                    challan.CustomerId = newCustomerId;
                    challan.ChallanDate = newChallanDate;
                    challan.DesignNo = newDesignNo;
                    challan.UpdatedAt = DateTime.UtcNow; // Update the timestamp
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
                throw new ArgumentNullException(nameof(challan), "Customer object cannot be null. error while updating record.");

            using (var db = new AppDbContext())
            {
                var existingChallan = db.Challans.Find(challan.ChallanId);

                if (existingChallan != null)
                {
                    // Update fields
                    if (existingChallan.CustomerId != challan.CustomerId)
                        existingChallan.CustomerId = challan.CustomerId;

                    if (existingChallan.DesignNo != challan.DesignNo)
                        existingChallan.DesignNo = challan.DesignNo;

                    if (existingChallan.ChallanDate != challan.ChallanDate)
                        existingChallan.ChallanDate = challan.ChallanDate;

                    existingChallan.UpdatedAt = DateTime.UtcNow;

                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"Challan with ID {challan.ChallanId} not found. error while updating record.");
                }
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
    }
}