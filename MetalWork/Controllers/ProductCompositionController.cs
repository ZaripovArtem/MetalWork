using MetalWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalWork.Controllers
{
    [Authorize(Roles = "Admin, Supplier")]
    public class ProductCompositionController : Controller
    {
        ApplicationContext db;
        public ProductCompositionController(ApplicationContext context) 
        {
            db = context;
        }
        public IActionResult Index()
        {
            var pc = db.ProductCompositions.Include(p => p.Product).Include(p => p.Material).ToList();
            return View(pc);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SelectList product = new SelectList(db.Products, "Id", "Name");
            ViewBag.Product = product;
            SelectList material = new SelectList(db.Materials, "Id", "Name");
            ViewBag.Material = material;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductComposition productComposition)
        {
            db.ProductCompositions.Add(productComposition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ProductComposition productComposition = db.ProductCompositions.Find(id);
            if(productComposition != null)
            {
                SelectList product = new SelectList(db.Products, "Id", "Name");
                ViewBag.Product = product;
                SelectList material = new SelectList(db.Materials, "Id", "Name");
                ViewBag.Material = material;
                return View(productComposition);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ProductComposition productComposition)
        {
            db.Entry(productComposition).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                RedirectToAction("Index");
            }
            ProductComposition productComposition = db.ProductCompositions.Find(id);
            db.ProductCompositions.Remove(productComposition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
