using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        //TODO : unable to decide which update method is working for accept whole customer object
        public static void UpdateCustomer(Customer customer)
        {
            using (var db = new AppDbContext())
            {
                if (customer != null)
                {
                    customer.updatedAt = DateTime.UtcNow;
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Please provide a valid customer for the update process!");
                }
            }
        }

        public static void UpdateCustomer2(Customer customer)
        {
            using (var db = new AppDbContext())
            {
                if (customer != null)
                {
                    customer.updatedAt = DateTime.UtcNow;
                    db.customers.Attach(customer);
                    db.Entry(customer).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Please provide a valid customer for the update process!");
                }
            }
        }

        //Hybrid Approach – Pass Whole Object but Track Changes Manually

        //Only Updates Modified Fields – Prevents unnecessary database writes.
        //✔ No Need to Manually Pass Fields in Function Call – You pass the whole object, but only changed fields are updated.
        //✔ Scalable – Works well even if the Customer model has 20+ properties.


        public static void hybridUpdateCustomer(Customer customer)
        {
            using (var db = new AppDbContext())
            {
                var existingCustomer = db.customers.Find(customer.CustomerId);
                if (existingCustomer != null)
                {
                    if (existingCustomer.Name != customer.Name)
                        existingCustomer.Name = customer.Name;
                    if (existingCustomer.Phone_No != customer.Phone_No)
                        existingCustomer.Phone_No= customer.Phone_No;

                    existingCustomer.updatedAt = DateTime.UtcNow;
                    db.SaveChanges();
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
