using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNC.Models;

namespace WebNC.Controllers
{
    public class KhachController : Controller
    {
        private CSDLContext db = new CSDLContext();

        // GET: Khach
        public ActionResult Index()
        {
            return View(db.Sanhs.OrderBy(x => x.TenSanh).ToList());
        }

        public ActionResult ThucDon()
        {
            var monAns = db.MonAns;
            return View(monAns.ToList());
        }
        public ActionResult DichVu()
        {
            return View(db.DichVus.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KhachID,TenKhach,SDT,DiaChi,Email,Username,Password")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(khachHang);
        }
    }
}