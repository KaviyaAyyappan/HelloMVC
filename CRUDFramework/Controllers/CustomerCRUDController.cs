using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDFramework.Models;
using System.Runtime.Caching;

namespace CRUDFramework.Controllers
{
    //Storing the data in memory cache
    public class CustomerCRUDController : Controller
    {
        ObjectCache cache = MemoryCache.Default;
        List<Customer> customers;

        public CustomerCRUDController()
        {
            customers = cache["customers"] as List<Customer>;
            if(customers == null)
            {
                customers = new List<Customer>();
            }
        }

        public void SaveCache()
        {
            cache["customers"] = customers;
        }


        // GET: CustomerCRUD
        //Viewing of customer List
        
            
        public ActionResult Index()
        {
            return View(customers);
        }
        
        
        /*
        //Viewing of customer List with search option
        public ActionResult Index(string searchString)
        {
            Customer customer = customers.FirstOrDefault(c => c.Name == searchString);
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.Name.Contains(searchString)).ToList();
            }

            return View(customer);
        }
        */

        // Getting the customer detail by its ID
        public ActionResult Details(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }


        }
        
        // GET: CustomerCRUD/Create
        // Creating the  Add Customer form
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerCRUD/Create
        // Adding the data to customer
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            customer.Id = Guid.NewGuid().ToString();
            customers.Add(customer);
            SaveCache();
            return RedirectToAction("index");
        }

        // GET: CustomerCRUD/Edit/5
        //Viewing the customer data with their ID
        public ActionResult Edit(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }

        // POST: CustomerCRUD/Edit/5
        //Editing the customer data and save it into memory
        [HttpPost]
        public ActionResult Edit(string id, Customer customer)
        {
            Customer customerEdit = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                customerEdit.Name = customer.Name;
                customerEdit.Telephone = customer.Telephone;
                SaveCache();

                return RedirectToAction("Index");
            }
        }

        // GET: CustomerCRUD/Delete/5
        //Viewing the data with delete option
        public ActionResult Delete(string id)
        {
            Customer customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }

        // POST: CustomerCRUD/Delete/5
        [HttpPost]
        
        public ActionResult Delete(string id, Customer customer)
        {
            Customer customerDelete = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                customers.Remove(customerDelete);
                SaveCache();

                return RedirectToAction("Index");
            }
        }
    }
}
