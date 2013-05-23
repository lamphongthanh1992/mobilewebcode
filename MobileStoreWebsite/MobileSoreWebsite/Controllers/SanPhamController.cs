using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileStoreBLL;
using MobileStoreBLL.ViewModel;

namespace MobileSoreWebsite.Controllers
{
    public class SanPhamController : Controller
    {
        private MOBILESTOREDBEntities db = new MOBILESTOREDBEntities();

        //
        // GET: /SanPham/

        public ActionResult Index()
        {
            return View(db.SanPhams.ToList());
        }

        //
        // GET: /SanPham/Details/5

        public ActionResult Details(int id = 0)
        {
            ChiTietSanPham ctsp = new ChiTietSanPham();
            var q = from s in db.SanPhams.Include("BinhLuans")
                    where s.maSP == id
                    select s;

            SanPham sanpham = q.FirstOrDefault();
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ctsp.SanPham = sanpham;
            ctsp.DSBinhLuan = sanpham.BinhLuans.ToList();
            return View(ctsp);
        }

        //
        // GET: /SanPham/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SanPham/Create

        [HttpPost]
        public ActionResult Create(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sanpham);
        }

        //
        // GET: /SanPham/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        //
        // POST: /SanPham/Edit/5

        [HttpPost]
        public ActionResult Edit(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanpham);
        }

        //
        // GET: /SanPham/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        //
        // POST: /SanPham/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanpham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}