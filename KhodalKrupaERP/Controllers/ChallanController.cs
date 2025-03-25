using System;
using System.Collections.Generic;
using System.Linq;
using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;

namespace KhodalKrupaERP.Controllers
{
    public class ChallanController
{
    // ✅ Create a new Challan
    public void AddChallan(DateTime challanDate, int designNo, int customerId)
    {
        using (var db = new AppDbContext())
        {
            var challan = new Challan(customerId, designNo, challanDate);
            db.Challans.Add(challan);
            db.SaveChanges();
            Console.WriteLine("Challan added successfully!");
        }
    }

    // ✅ Get all challans
    public List<Challan> GetAllchallans()
    {
        using (var db = new AppDbContext())
        {
            return db.Challans.ToList();
        }
    }

    // ✅ Get a specific Challan by ID
    public Challan GetChallanById(int id)
    {
        using (var db = new AppDbContext())
        {
            return db.Challans.Find(id);
        }
    }

    // ✅ Update a Challan
    public void UpdateChallan(int id, DateTime newChallanDate, int newDesignNo)
    {
        using (var db = new AppDbContext())
        {
            var challan = db.Challans.Find(id);
            if (challan != null)
            {
                challan.ChallanDate = newChallanDate;
                challan.DesignNo = newDesignNo;
                challan.UpdatedAt = DateTime.UtcNow; // Update the timestamp
                db.SaveChanges();
                Console.WriteLine("Challan updated successfully!");
            }
            else
            {
                Console.WriteLine("Challan not found!");
            }
        }
    }

    // ✅ Delete a Challan
    public void DeleteChallan(int id)
    {
        using (var db = new AppDbContext())
        {
            var challan = db.Challans.Find(id);
            if (challan != null)
            {
                db.Challans.Remove(challan);
                db.SaveChanges();
                Console.WriteLine("Challan deleted successfully!");
            }
            else
            {
                Console.WriteLine("Challan not found!");
            }
        }
    }
}

}
