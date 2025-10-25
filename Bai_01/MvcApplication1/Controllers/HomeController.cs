using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data.SqlClient;
namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ql_tintucEntities data = new ql_tintucEntities();
        public ActionResult Index()
        {
            List<THELOAITIN> ds = data.THELOAITINs.ToList();
            return View(ds);
        }
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(THELOAITIN tin)
        {
            data.THELOAITINs.Add(tin);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var eb_tin = data.THELOAITINs.First(i => i.IDLOAI == id);
            return View(eb_tin);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var ltin = data.THELOAITINs.First(m => m.IDLOAI == id);
            var e_loai_tin = collection["TENTHELOAI"];
            ltin.IDLOAI = id;
            ltin.TENTHELOAI = e_loai_tin;
            
            UpdateModel(ltin);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var d_tin = data.THELOAITINs.Where(m => m.IDLOAI == id).First();
            return View(d_tin);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var d_tin = data.THELOAITINs.Where(i => i.IDLOAI == id).First();
            data.THELOAITINs.Remove(d_tin);
            data.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            var tin = data.THELOAITINs.First(m => m.IDLOAI == id);
            return View(tin);
        }
    }
}
