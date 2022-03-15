using MetalWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalWork.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationContext db;

        public CustomerController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
