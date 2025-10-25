using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai3.Models;
using System.Data.Entity;

namespace Bai3.Controllers
{
    public class HomeController : Controller
    {
       public Ql_NhanSuEntities db=new Ql_NhanSuEntities();
        public ActionResult Index()
        {

            return View(db.tbl_Employee.ToList());
        }

        public ActionResult Create()
        {
            
            return View();
        }
        
        public ActionResult CreateOnSubmit(tbl_Employee id)
        {
            if(ModelState.IsValid)
            {
                db.tbl_Employee.Add(id);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
           tbl_Employee em=db.tbl_Employee.FirstOrDefault(n=>n.Id==id);


            return View(em);
        }
        [HttpPost]
        public ActionResult EditOnSubmit(tbl_Employee emp)
        {
            if (ModelState.IsValid)
            {
                tbl_Employee oldItem=db.tbl_Employee.FirstOrDefault(x=>x.Id== emp.Id); // lấy lại giá trị cũ (lấy cái id hiện tại cái mà bằng cái id của cái Edit đã lụm ở trên)
                oldItem.Name = emp.Name; //cập nhật lại giá trị mới  
                oldItem.DeptId= emp.DeptId;
                oldItem.City= emp.City;

                db.Entry(oldItem).State=System.Data.Entity.EntityState.Modified; //cập nhật lại trạng thái của dữ liệu
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            tbl_Employee de = db.tbl_Employee.FirstOrDefault(n => n.Id == id);


            return View(de);
        }
        public ActionResult DeleteOnSubmit(tbl_Employee emp)
        {
            if (ModelState.IsValid)
            {
                tbl_Employee oldItem = db.tbl_Employee.FirstOrDefault(x => x.Id == emp.Id); // lấy lại giá trị cũ (lấy cái id hiện tại cái mà bằng cái id của cái Edit đã lụm ở trên)


                db.tbl_Employee.Remove(oldItem);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            tbl_Employee details = db.tbl_Employee.FirstOrDefault(n => n.Id == id);


            return View(details);
        }
        public ActionResult EmpDep()
        {
            var inf = db.tbl_Employee.Include(x=>x.tbl_Department).ToList();
            return View(inf);
        }
        public ActionResult DanhSachDep()
        {
            List<tbl_Department> de =db.tbl_Department.ToList();
            return View(de);
        }
        public ActionResult NhanVienTheoPhong(int id)
        {
            var dsnv = db.tbl_Employee.Where(x => x.DeptId == id).ToList();
            return PartialView("_DanhSachNV", dsnv);
        }

        //public ActionResult DetailDep(int id)
        //{
        //    tbl_Department dep=db.tbl_Department.FirstOrDefault(x=>x.DeptId== id);
        //    return View(dep);
        //}
    }
}