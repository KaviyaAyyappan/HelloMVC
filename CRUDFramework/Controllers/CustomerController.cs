using CRUDFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Caching;

namespace CRUDFramework.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        // Viewing the customer data model with hard coded value for one customer
        /*
        public ActionResult ViewCustomer()
        {
            Customer customer = new Customer();
            customer.Id = 1;
            customer.Name = "Rohit";
            customer.Telephone = 555;
            return View(customer);
        }
        */

            
        public ActionResult ViewCustomer(Customer postedCustomer)
        {
            Customer customer = new Customer();
            customer.Id = postedCustomer.Id;
            customer.Name = postedCustomer.Name;
            customer.Telephone = postedCustomer.Telephone;
            return View(customer);
        }

        //Getting data from user
        public ActionResult AddCustomer()
        {
            return View();
        }

        //Viewing the customer data model with hard coded value for multicustomer using List
        public ActionResult CustomerList()
        {
            List<Customer> customer = new List<Customer>();
            customer.Add(new Customer {Name="Jack",Telephone=555 });
            customer.Add(new Customer { Name = "Jacksson", Telephone = 666 });
            return View(customer);
        }

    }
}