using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebNC.Common;
using WebNC.Models;

namespace WebNC.Controllers
{
    public class DatTiecKhachController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: DatTiecKhach
        public ActionResult Index()
        {
            var user = (KhachHang)Session[Constant.USER_INFO];
            var datTiecs = db.DatTiecs.Include(d => d.DichVu).Include(d => d.KhachHang).Include(d => d.Menu).Include(d => d.Sanh).Where(x => x.KhachID == user.KhachID);
            return View(datTiecs.ToList());
        }

        public ActionResult Searching(string ten)
        {
            var dattiec = db.DatTiecs.Where(x => x.ChuRe.Contains(ten) || x.CoDau.Contains(ten)).ToList();
            return View("Index", dattiec);
        }

        // GET: DatTiecKhach/Create
        public ActionResult Create()
        {
            ViewBag.Sanh = db.Sanhs.OrderBy(x=>x.TenSanh).ToList();
            ViewBag.DichVu = db.DichVus.OrderBy(x => x.TenDichVu).ToList();
            ViewBag.MonAn = db.MonAns.OrderBy(x => x.TenMonAn).ToList();
            ViewBag.Menu = db.Menus.OrderBy(x => x.TenMenu).ToList();
            //ViewBag.KhachID = new SelectList(db.KhachHangs, "KhachID", "TenKhach");
            //ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "TenMenu");
            //ViewBag.SanhID = new SelectList(db.Sanhs, "SanhID", "TenSanh");
            return View();
        }

        // POST: DatTiecKhach/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TiecID,ChuRe,CoDau,NgayDat,SoBan,GiaTiec,MenuID,SanhID,KhachID,DichVuID")] DatTiec datTiec)
        {
            if (ModelState.IsValid)
            {
                var sum = db.MonAns.ToList().Where(x => x.MenuID == datTiec.MenuID).Sum(x => x.GiaMonAn);
                var dichvu = db.DichVus.ToList().SingleOrDefault(x => x.DichVuID == datTiec.DichVuID);
                datTiec.GiaTiec = (sum * datTiec.SoBan)+dichvu.GiaDichVu;
                db.DatTiecs.Add(datTiec);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.DichVuID = new SelectList(db.DichVus, "DichVuID", "TenDichVu", datTiec.DichVuID);
            ViewBag.KhachID = new SelectList(db.KhachHangs, "KhachID", "TenKhach", datTiec.KhachID);
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "TenMenu", datTiec.MenuID);
            ViewBag.SanhID = new SelectList(db.Sanhs, "SanhID", "TenSanh", datTiec.SanhID);
            return View(datTiec);
        }

        // GET: DatTiecKhach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatTiec datTiec = db.DatTiecs.Find(id);
            if (datTiec == null)
            {
                return HttpNotFound();
            }
            ViewBag.DichVuID = new SelectList(db.DichVus, "DichVuID", "TenDichVu", datTiec.DichVuID);
            ViewBag.KhachID = new SelectList(db.KhachHangs, "KhachID", "TenKhach", datTiec.KhachID);
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "TenMenu", datTiec.MenuID);
            ViewBag.SanhID = new SelectList(db.Sanhs, "SanhID", "TenSanh", datTiec.SanhID);
            return View(datTiec);
        }

        // POST: DatTiecKhach/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TiecID,ChuRe,CoDau,NgayDat,SoBan,GiaTiec,MenuID,SanhID,KhachID,DichVuID")] DatTiec datTiec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datTiec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DichVuID = new SelectList(db.DichVus, "DichVuID", "TenDichVu", datTiec.DichVuID);
            ViewBag.KhachID = new SelectList(db.KhachHangs, "KhachID", "TenKhach", datTiec.KhachID);
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "TenMenu", datTiec.MenuID);
            ViewBag.SanhID = new SelectList(db.Sanhs, "SanhID", "TenSanh", datTiec.SanhID);
            return View(datTiec);
        }

        // GET: DatTiecKhach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatTiec datTiec = db.DatTiecs.Find(id);
            if (datTiec == null)
            {
                return HttpNotFound();
            }
            return View(datTiec);
        }

        // POST: DatTiecKhach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatTiec datTiec = db.DatTiecs.Find(id);
            db.DatTiecs.Remove(datTiec);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
