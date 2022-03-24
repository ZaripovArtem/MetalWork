using MetalWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalWork.Controllers
{
    public class MaterialController : Controller
    {
        ApplicationContext db;

        public MaterialController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Materials.ToList());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id != null)
            {
                var material = db.Materials.Find(id);
                return View(material);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Material material)
        {
            db.Entry(material).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var material = db.Materials.Find(id);
            db.Materials.Remove(material);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Material material)
        {
            db.Materials.Add(material);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
