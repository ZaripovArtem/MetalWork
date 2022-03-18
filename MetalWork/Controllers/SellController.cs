using MetalWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalWork.Controllers
{
    public class SellController : Controller
    {
        ApplicationContext db;

        public SellController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var sell = db.Sells.Include(p => p.Customer).Include(p => p.Product);
            return View(sell.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            SelectList customer = new SelectList(db.Customers, "Id", "Surname");
            ViewBag.Customer = customer;
            SelectList product = new SelectList(db.Products, "Id", "Name");
            ViewBag.Product = product;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sell sell)
        {
            db.Sells.Add(sell);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Sell sell = db.Sells.Find(id);
            if (sell != null)
            {
                return View(sell);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Sell sell)
        {
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id ==null)
            {
                RedirectToAction("Index");
            }
            Sell sell = db.Sells.Find(id);
            db.Sells.Remove(sell);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
