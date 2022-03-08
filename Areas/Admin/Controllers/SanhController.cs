using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebNC.Models;
using System.IO;
using WebNC.Controllers;
using WebNC.Common;

namespace WebNC.Areas.Admin.Controllers
{
    public class SanhController : Controller
    {
        private CSDLContext db = new CSDLContext();

        // GET: Admin/Sanh
        public ActionResult Index()
        {
            var user = (KhachHang)Session[Constant.USER_INFO];
            if (user.Username == "admin")
            {
                return View(db.Sanhs.OrderBy(x => x.TenSanh).ToList());
            }
            return Redirect("/Home");
        }

        public ActionResult Searching(string tensanh)
        {
            var sanh = db.Sanhs.Where(x => x.TenSanh.Contains(tensanh)).ToList();
            return View("Index", sanh);
        }

        // GET: Admin/Sanh/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanh sanh = db.Sanhs.Find(id);
            if (sanh == null)
            {
                return HttpNotFound();
            }
            return View(sanh);
        }

        // GET: Admin/Sanh/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/Sanh/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SanhID,TenSanh,MoTa,HinhSanh")] Sanh sanh, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string fullfilename = filename.Split('.')[0] + "(" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ")." + filename.Split('.')[1];
                string path = Path.Combine(Server.MapPath("~/Content/Images/Sanh"), fullfilename);
                postedFile.SaveAs(path);
                sanh.HinhSanh = fullfilename;
                db.Sanhs.Add(sanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanh);
        }

        // GET: Admin/Sanh/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanh sanh = db.Sanhs.Find(id);
            if (sanh == null)
            {
                return HttpNotFound();
            }
            return View(sanh);
        }

        // POST: Admin/Sanh/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SanhID,TenSanh,MoTa,HinhSanh")] Sanh sanh, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    string filename = Path.GetFileName(postedFile.FileName);
                    string fullfilename = filename.Split('.')[0] + "(" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ")." + filename.Split('.')[1];
                    string path = Path.Combine(Server.MapPath("~/Content/Images/Sanh"), fullfilename);
                    postedFile.SaveAs(path);
                    sanh.HinhSanh = fullfilename;
                }
                db.Entry(sanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanh);
        }

        // GET: Admin/Sanh/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sanh sanh = db.Sanhs.Find(id);
            if (sanh == null)
            {
                return HttpNotFound();
            }
            return View(sanh);
        }

        // POST: Admin/Sanh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sanh sanh = db.Sanhs.Find(id);
            db.Sanhs.Remove(sanh);
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
