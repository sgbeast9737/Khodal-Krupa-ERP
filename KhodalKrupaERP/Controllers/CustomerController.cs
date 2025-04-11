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

        #region less_used_methods

        // ✅ Create a new customer
        public static void AddCustomer(string name, string phoneNo)
        {
            using (var db = new AppDbContext())
            {
                var customer = new Customer(name, phoneNo);
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        // ✅ Update a customer
        public static void UpdateCustomer(int id, string newName, string newPhoneNo)
        {
            using (var db = new AppDbContext())
            {
                var customer = db.Customers.Find(id);
                if (customer != null)
                {
                    customer.Name = newName;
                    customer.PhoneNo = newPhoneNo;
                    customer.UpdatedAt = DateTime.Now;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"customer not found of given id {id} for update process");
                }
            }
        }

        //Hybrid Approach – Pass Whole Object but Track Changes Manually

        //Only Updates Modified Fields – Prevents unnecessary database writes.
        //✔ No Need to Manually Pass Fields in Function Call – You pass the whole object, but only changed fields are updated.
        //✔ Scalable – Works well even if the Customer model has 20+ properties.

        public static void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer), "Customer object cannot be null. error while updating record.");

            using (var db = new AppDbContext())
            {
                var existingCustomer = db.Customers.Find(customer.CustomerId);

                if (existingCustomer != null)
                {
                    // Update fields
                    if (existingCustomer.Name != customer.Name)
                        existingCustomer.Name = customer.Name;
                    if (existingCustomer.PhoneNo != customer.PhoneNo)
                        existingCustomer.PhoneNo = customer.PhoneNo;

                    existingCustomer.UpdatedAt = DateTime.Now;

                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"Customer with ID {customer.CustomerId} not found. error while updating record.");
                }
            }
        }

        #endregion less_used_methods
    }
}

//TODO : Example of how to perform update operation on sf data grid

//private void sfDataGrid1_CurrentCellEndEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellEndEditEventArgs e)
//{
//    if (e.DataRow.RowData is Customer customer)
//    {
//        try
//        {
//            CustomerController.UpdateCustomer(customer); // Pass whole object
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show($"Not updated: {ex.Message}", "Error while updating record", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }
//    }
//}

//TODO : validation example of sf data grid data

//private void sfDataGrid1_RowValidating(object sender, Syncfusion.WinForms.DataGrid.Events.RowValidatingEventArgs e)
//{
//    if (e.DataRow.RowData is Customer customer)
//    {
//        // Example: Validate Name field
//        if (string.IsNullOrWhiteSpace(customer.Name))
//        {
//            e.IsValid = false;
//            e.ErrorMessages["Name"] = "Customer name is required!";
//        }

//        // Example: Validate PhoneNo field
//        if (string.IsNullOrWhiteSpace(customer.PhoneNo) || customer.PhoneNo.Length < 10)
//        {
//            e.IsValid = false;
//            e.ErrorMessages["PhoneNo"] = "Valid phone number is required!";
//        }
//    }
//}


//TODO : insert code example using sf data grid but need modify manually track if id is exist or not if exist mean update else insert

//private void sfDataGrid1_CurrentRowValidated(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentRowValidatedEventArgs e)
//{
//    if (e.DataRow.RowData is Customer newCustomer)
//    {
//        using (var db = new TestERPContext())
//        {
//            db.Customers.Add(newCustomer);
//            db.SaveChanges();
//        }

//        MessageBox.Show("New customer added successfully!", "Success");
//    }
//}


//TODO : sfDataGrid1_CurrentRowValidated Modify Code to Handle Both Insert & Update
//private void sfDataGrid1_CurrentRowValidated(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentRowValidatedEventArgs e)
//{
//    if (e.DataRow.RowData is Customer customer)
//    {
//        using (var db = new TestERPContext())
//        {
//            if (customer.CustomerId == 0) // INSERT CASE
//            {
//                db.Customers.Add(customer);
//            }
//            else // UPDATE CASE
//            {
//                db.Customers.Update(customer); // or db.Entry(customer).State = EntityState.Modified;
//            }

//            db.SaveChanges();
//        }

//        MessageBox.Show("Data saved successfully!", "Success");
//        RefreshGrid(); // Refresh the grid after operation
//    }
//}

/*
 * //TODO : one more exaple of update case
 private void sfDataGrid1_CurrentCellEndEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellEndEditEventArgs e)
{
if (e.DataRow.RowData is Customer customer && customer.CustomerId != 0) // Only update existing records
{
    using (var db = new TestERPContext())
    {
        db.Customers.Update(customer);
        db.SaveChanges();
    }
}
}

 */
