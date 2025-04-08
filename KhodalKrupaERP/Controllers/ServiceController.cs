using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace KhodalKrupaERP.Controllers
{
    public class ServiceController
    {
        // ✅ Get all bindable services
        public static BindingList<Service> GetAllBindableServices()
        {
            using (var db = new AppDbContext())
            {
                return new BindingList<Service>(db.Services.ToList());
            }
        }

        // ✅ Get all services
        public static List<Service> GetAllServices()
        {
            using (var db = new AppDbContext())
            {
                return db.Services.ToList();
            }
        }

        // ✅ Get a specific service by ID
        public static Service GetServiceById(int id)
        {
            using (var db = new AppDbContext())
            {
                return db.Services.Find(id);
            }
        }

        public static void UpdateOrAddService(Service service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service), "Service object cannot be null. error while updating record");

            using (var db = new AppDbContext())
            {
                // Check if the service already exists in the database
                //var existingService = db.Services.AsNoTracking().FirstOrDefault(c => c.ServiceId == service.ServiceId);
                Service existingService = db.Services.Find(service.ServiceId);

                if (existingService != null)
                {
                    // If the entity exists, update it
                    if (existingService.Name != service.Name)
                        existingService.Name = service.Name;

                    existingService.UpdatedAt = DateTime.Now;
                }
                else
                {
                    // If the entity does not exist, add it as a new entity
                    Service newService = new Service(service.Name);
                    db.Services.Add(newService);
                }

                db.SaveChanges();
            }
        }

        // ✅ Delete a service
        public static void DeleteService(int id)
        {
            using (var db = new AppDbContext())
            {
                var service = db.Services.Find(id);
                if (service != null)
                {
                    db.Services.Remove(service);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"service not found of given id {id} for delete process");
                }
            }
        }

        #region less_used_methods

        // ✅ Create a new service
        public static void AddService(string name, string phoneNo)
        {
            using (var db = new AppDbContext())
            {
                var service = new Service(name);
                db.Services.Add(service);
                db.SaveChanges();
            }
        }

        // ✅ Update a Service
        public static void UpdateService(int id, string newName, string newPhoneNo)
        {
            using (var db = new AppDbContext())
            {
                var service = db.Services.Find(id);
                if (service != null)
                {
                    service.Name = newName;
                    service.UpdatedAt = DateTime.Now;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"service not found of given id {id} for update process");
                }
            }
        }

        //Hybrid Approach – Pass Whole Object but Track Changes Manually

        //Only Updates Modified Fields – Prevents unnecessary database writes.
        //✔ No Need to Manually Pass Fields in Function Call – You pass the whole object, but only changed fields are updated.
        //✔ Scalable – Works well even if the service model has 20+ properties.

        public static void UpdateService(Service service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service), "service object cannot be null. error while updating record.");

            using (var db = new AppDbContext())
            {
                var existingService = db.Services.Find(service.ServiceId);

                if (existingService != null)
                {
                    // Update fields
                    if (existingService.Name != service.Name)
                        existingService.Name = service.Name;
                 
                    existingService.UpdatedAt = DateTime.Now;

                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"Service with ID {service.ServiceId} not found. error while updating record.");
                }
            }
        }

        #endregion less_used_methods
    }
}