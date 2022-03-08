using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebNC.Controllers;
using WebNC.Models;

namespace WebNC.Areas.Admin.Controllers
{
    public class DichVuController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: Admin/DichVu
        public ActionResult Index()
        {
            return View(db.DichVus.ToList());
        }

        public ActionResult Searching(string tendichvu)
        {
            var dichvu = db.DichVus.Where(x => x.TenDichVu.Contains(tendichvu)).ToList();
            return View("Index", dichvu);
        }

        // GET: Admin/DichVu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // GET: Admin/DichVu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DichVu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DichVuID,TenDichVu,HinhThuc,GiaDichVu,HinhDichVu")] DichVu dichVu, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string fullfilename = filename.Split('.')[0] + "(" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ")." + filename.Split('.')[1];
                string path = Path.Combine(Server.MapPath("~/Content/Images/DichVu"), fullfilename);
                postedFile.SaveAs(path);
                dichVu.HinhDichVu = fullfilename;
                db.DichVus.Add(dichVu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dichVu);
        }

        // GET: Admin/DichVu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // POST: Admin/DichVu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DichVuID,TenDichVu,HinhThuc,GiaDichVu,HinhDichVu")] DichVu dichVu, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    string filename = Path.GetFileName(postedFile.FileName);
                    string fullfilename = filename.Split('.')[0] + "(" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ")." + filename.Split('.')[1];
                    string path = Path.Combine(Server.MapPath("~/Content/Images/DichVu"), fullfilename);
                    postedFile.SaveAs(path);
                    dichVu.HinhDichVu = fullfilename;
                }
                db.Entry(dichVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dichVu);
        }

        // GET: Admin/DichVu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVu dichVu = db.DichVus.Find(id);
            if (dichVu == null)
            {
                return HttpNotFound();
            }
            return View(dichVu);
        }

        // POST: Admin/DichVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DichVu dichVu = db.DichVus.Find(id);
            db.DichVus.Remove(dichVu);
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
