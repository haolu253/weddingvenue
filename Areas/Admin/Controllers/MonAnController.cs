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
    public class MonAnController : BaseController
    {
        private CSDLContext db = new CSDLContext();

        // GET: Admin/MonAn
        public ActionResult Index()
        {
            ViewBag.MENU = db.Menus.ToList();
            var monAns = db.MonAns.Include(m => m.Menu);
            return View(monAns.ToList());
        }
        public ActionResult Searching(string tenmon, int menu)
        {
            var monan = db.MonAns.Where(x => x.MenuID == menu && x.TenMonAn.Contains(tenmon)).ToList();
            ViewBag.MENU = db.Menus.ToList();
            return View("Index",monan);
        }

        // GET: Admin/MonAn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // GET: Admin/MonAn/Create
        public ActionResult Create()
        {
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "TenMenu");
            return View();
        }

        // POST: Admin/MonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MonAnID,TenMonAn,GiaMonAn,HinhMonAn,MenuID")] MonAn monAn, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string fullfilename = filename.Split('.')[0] + "(" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ")." + filename.Split('.')[1];
                string path = Path.Combine(Server.MapPath("~/Content/Images/MonAn"), fullfilename);
                postedFile.SaveAs(path);
                monAn.HinhMonAn = fullfilename;
                db.MonAns.Add(monAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "TenMenu", monAn.MenuID);
            return View(monAn);
        }

        // GET: Admin/MonAn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "TenMenu", monAn.MenuID);
            return View(monAn);
        }

        // POST: Admin/MonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MonAnID,TenMonAn,GiaMonAn,HinhMonAn,MenuID")] MonAn monAn, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    string filename = Path.GetFileName(postedFile.FileName);
                    string fullfilename = filename.Split('.')[0] + "(" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ")." + filename.Split('.')[1];
                    string path = Path.Combine(Server.MapPath("~/Content/Images/MonAn"), fullfilename);
                    postedFile.SaveAs(path);
                    monAn.HinhMonAn = fullfilename;
                }
                db.Entry(monAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuID = new SelectList(db.Menus, "MenuID", "TenMenu", monAn.MenuID);
            return View(monAn);
        }

        // GET: Admin/MonAn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // POST: Admin/MonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonAn monAn = db.MonAns.Find(id);
            db.MonAns.Remove(monAn);
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
