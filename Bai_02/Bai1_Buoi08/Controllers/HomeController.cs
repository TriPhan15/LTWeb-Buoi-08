using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai1_Buoi08.Models;
using System.IO;
using PagedList;
namespace Bai1_Buoi08.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ql_hanghoaEntities data =  new ql_hanghoaEntities();
        public ActionResult Index(int ? page)
        {
            int pagesize = 5;
            int pagenumber = (page ?? 1);
            var ds = data.saches.OrderBy(s=>s.masach).ToPagedList(pagenumber,pagesize);
            return View(ds);
        }
        public ActionResult Create()
        {
            // dua du lieu vao dropdown list
            ViewBag.macd = new SelectList(data.chudes.ToList().OrderBy(n => n.tenchude), "MaCD", "TenChuDe");
            ViewBag.manxb = new SelectList(data.nhaxuatbans.ToList().OrderBy(m => m.tennxh), "MANXB", "tennxh");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(sach s, HttpPostedFileBase fileupload)
        {
            // dua du lieu vao dropdown list
            ViewBag.macd = new SelectList(data.chudes.ToList().OrderBy(n => n.tenchude), "MaCD", "TenChuDe");
            ViewBag.manxb = new SelectList(data.nhaxuatbans.ToList().OrderBy(m => m.tennxh), "MANXB", "tennxh");
            // kiem tra duong dan file
            if (fileupload == null)
            {
                ViewBag.tb = "Vui long chon anh bia";
                return View();
            }
            if(ModelState.IsValid){
                // luu ten file
                var filename=Path.GetFileName(fileupload.FileName);
                // luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Hinh"),filename);
                // Kiem tra hinh anh ton tai chua
                if (System.IO.File.Exists(path))
                {
                    ViewBag.tb = "Hinh anh da ton tai !";

                }
                else
                {
                    // Luu hinh anh vao duong dan
                    fileupload.SaveAs(path);
                }
                // gan ten anh vao doi tuong
                s.anhbia = filename;
                // Luu vao csdl
                data.saches.Add(s);
                data.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            // lấy ra đối tượng theo mã 
            sach s = data.saches.SingleOrDefault(n => n.masach.Trim() == id.Trim());
            if (s == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(s);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            // lấy ra đối tượng theo mã 
            sach s = data.saches.SingleOrDefault(n => n.masach.Trim() == id.Trim());

            if (s == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(s);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult SubmitDelete(string id)
        {
            // lấy ra đối tượng theo mã 
            sach s = data.saches.SingleOrDefault(n => n.masach.Trim() == id.Trim());

            if (s == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.saches.Remove(s);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
            // lấy ra đối tượng theo mã 
            sach s = data.saches.SingleOrDefault(n => n.masach.Trim() == id.Trim());

            if (s == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.macd = new SelectList(data.chudes.ToList().OrderBy(n => n.tenchude), "MaCD", "TenChuDe");
            ViewBag.manxb = new SelectList(data.nhaxuatbans.ToList().OrderBy(m => m.tennxh), "MANXB", "tennxh");
            return View(s);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(sach s, HttpPostedFileBase fileupload)
        {
            // dua du lieu vao dropdown list
            ViewBag.macd = new SelectList(data.chudes.ToList().OrderBy(n => n.tenchude), "MaCD", "TenChuDe");
            ViewBag.manxb = new SelectList(data.nhaxuatbans.ToList().OrderBy(m => m.tennxh), "MANXB", "tennxh");
            // Tìm đối tượng cũ trong CSDL
            sach sachUpdate = data.saches.SingleOrDefault(n => n.masach == s.masach);
            if (sachUpdate == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            if (fileupload != null)
            {
                var filename = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/Hinh"), filename);
                if (!System.IO.File.Exists(path))
                {
                    fileupload.SaveAs(path);
                }
                sachUpdate.anhbia = filename;
            }

            // Cập nhật các thuộc tính khác
            sachUpdate.tensach = s.tensach;
            sachUpdate.giaban = s.giaban;
            sachUpdate.mota = s.mota;
            sachUpdate.ngaycapnhat = s.ngaycapnhat;
            sachUpdate.soluongton = s.soluongton;
            sachUpdate.macd = s.macd;
            sachUpdate.manxb = s.manxb;
            // Lưu thay đổi
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
