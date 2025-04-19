using KhodalKrupaERP.Core;
using KhodalKrupaERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public static Service GetServiceById(int serviceId)
        {
            using (var db = new AppDbContext())
            {
                Service service = db.Services.Find(serviceId);
                if (service == null)
                {
                    throw new Exception("No Service record found of id " + serviceId);
                }
                else
                {
                    return service;
                }
            }
        }

        public static void UpdateOrAddService(Service service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service), "Service object cannot be null. error while updating record");

            using (var db = new AppDbContext())
            {
                // Check if the service already exists in the database
                Service existingService = db.Services.Find(service.ServiceId);

                if (existingService != null)
                {
                    // If the entity exists, update it
                    if (existingService.Name != service.Name)
                    {
                        existingService.Name = service.Name;
                        existingService.UpdatedAt = DateTime.Now;
                    }
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
        public static void DeleteService(int serviceId)
        {
            using (var db = new AppDbContext())
            {
                var service = db.Services.Find(serviceId);
                if (service == null)
                {
                    throw new Exception($"service not found of given id {serviceId} for delete process");
                }
                else if (service.ChallanTransactions.Count > 0)
                {
                    throw new Exception($"Service can't be deleted it has related challan transactions in system.\n\nPlease remove all related challan transactions of {service.Name} service than delete service.");
                }
                else
                {
                    db.Services.Remove(service);
                    db.SaveChanges();
                }
            }
        }
    }
}