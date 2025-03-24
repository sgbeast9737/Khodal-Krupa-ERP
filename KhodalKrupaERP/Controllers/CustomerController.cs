using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KhodalKrupaERP.Controllers
{
    public class CustomerController
    {
        // ✅ Create a new customer
        public static void AddCustomer(string name, string phoneNo)
        {
            using (var db = new AppDbContext())
            {
                var customer = new Customer(name, phoneNo);
                db.customers.Add(customer);
                db.SaveChanges();
            }
        }

        // ✅ Get all customers
        public static List<Customer> GetAllcustomers()
        {
            using (var db = new AppDbContext())
            {
                return db.customers.ToList();
            }
        }

        // ✅ Get a specific customer by ID
        public static Customer GetCustomerById(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.customers.Find(id);
            }
        }

        // ✅ Update a customer
        public static void UpdateCustomer(int id, string newName, string newPhoneNo)
        {
            using (var db = new AppDbContext())
            {
                var customer = db.customers.Find(id);
                if (customer != null)
                {
                    customer.Name = newName;
                    customer.Phone_No = newPhoneNo;
                    customer.updatedAt = DateTime.UtcNow;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"customer not found of given id {id} for update process");
                }
            }
        }

        // ✅ Delete a customer
        public static void DeleteCustomer(int id)
        {
            using (var db = new AppDbContext())
            {
                var customer = db.customers.Find(id);
                if (customer != null)
                {
                    db.customers.Remove(customer);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"customer not found of given id {id} for delete process");
                }
            }
        }
    }
}
