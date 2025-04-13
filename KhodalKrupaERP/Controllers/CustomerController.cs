using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace KhodalKrupaERP.Controllers
{
    public class CustomerController
    {
        // ✅ Get all bindable customers
        public static BindingList<Customer> GetAllBindableCustomers()
        {
            using (var db = new AppDbContext())
            {
                return new BindingList<Customer>(db.Customers.ToList());
            }
        }

        // ✅ Get all customers
        public static List<Customer> GetAllCustomers()
        {
            using (var db = new AppDbContext())
            {
                return db.Customers.ToList();
            }
        }

        // ✅ Get a specific customer by ID
        public static Customer GetCustomerById(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Customers.Find(id);
            }
        }

        public static void UpdateOrAddCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer), "Customer object cannot be null. error while updating record");

            using (var db = new AppDbContext())
            {
                // Check if the customer already exists in the database
                //var existingCustomer = db.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerId == customer.CustomerId);
                Customer existingCustomer = db.Customers.Find(customer.CustomerId);

                if (existingCustomer != null)
                {
                    // If the entity exists, update it
                    if (existingCustomer.Name != customer.Name)
                        existingCustomer.Name = customer.Name;
                    if (existingCustomer.PhoneNo != customer.PhoneNo)
                        existingCustomer.PhoneNo = customer.PhoneNo;

                    existingCustomer.UpdatedAt = DateTime.Now;
                }
                else
                {
                    // If the entity does not exist, add it as a new entity
                    Customer newCustomer = new Customer(customer.Name, customer.PhoneNo);
                    db.Customers.Add(newCustomer);
                }

                db.SaveChanges();
            }
        }

        // ✅ Delete a customer
        public static void DeleteCustomer(int id)
        {
            using (var db = new AppDbContext())
            {
                var customer = db.Customers.Find(id);

                if (customer == null)
                {
                    throw new Exception($"Customer not found of given id {id} for delete process");
                }
                else if(customer.Challans.Count > 0)
                {
                    throw new Exception($"Customer can't be deleted it has related challans in system.\n\nPlease remove all related challans of {customer.Name} customer than delete customer.");
                }
                else
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                }
            }
        }
    }
}