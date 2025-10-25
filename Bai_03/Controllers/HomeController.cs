using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb08_Tuan08.Models;

namespace LTWeb08_Tuan08.Controllers
{
    public class HomeController : Controller
    {
        public Model1 md = new Model1();
        public ActionResult Index()
        {
            List<theloaitin> theloaitins =md.theloaitins.ToList();
            return View(theloaitins);
        }
        
        [HttpGet]                                                       
        
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(theloaitin tlt)
        {
            if (ModelState.IsValid)
            {
                md.theloaitins.Add(tlt);
                md.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlt);
        }

        public ActionResult Edits(int idloai)
        {
           var tin=md.theloaitins.First(s=>s.IDLoai==idloai);
            return View(tin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(theloaitin tlt)
        {
            //var sua=md.theloaitins.First(s=>s.IDLoai == idloai);
            //var tin = form["Tentheloai"];

            //sua.IDLoai = idloai;

            //sua.Tentheloai = tin;

            //UpdateModel(sua);
            //md.SaveChanges();
            //return RedirectToAction("Index");
            if (ModelState.IsValid)
            {
                md.Entry(tlt).State = System.Data.Entity.EntityState.Modified;
                md.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlt);
        }
        public ActionResult Details(int idloai)
        {
            var de = md.theloaitins.First(s => s.IDLoai == idloai);

            return View(de);
        }
        
        
        public ActionResult Delete(int idloai)
        {
            var del =md.theloaitins.First(s=>s.IDLoai==idloai);

            return View(del);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Xoa(int idloai)
        {
            var xoatin=md.theloaitins.Where(s=>s.IDLoai==idloai).First();

            md.theloaitins.Remove(xoatin);
            md.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}