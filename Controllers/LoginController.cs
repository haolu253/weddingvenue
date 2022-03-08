using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNC.Common;
using WebNC.Models;

namespace WebNC.Controllers
{
    public class LoginController : Controller
    {
        private CSDLContext db = new CSDLContext();
        // GET: Login
        public ActionResult Index()
        {
            Session[Constant.USER_INFO] = null;
            Session[Constant.USER] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            try
            {
                if (username == "admin")
                {
                    if (password == "admin")
                    {
                        var usersession = new Login();
                        usersession.Username = username;
                        usersession.Password = password;
                        Session.Add(Constant.USER, usersession);
                        var kh = db.KhachHangs.SingleOrDefault(x => x.Username == username);
                        Session[Constant.USER_INFO] = kh;
                        return RedirectToAction("Index", "Sanh", new { area = "Admin" });
                    }
                    else
                    {
                        return View("Index");
                    }
                }
                var khachang = db.KhachHangs.SingleOrDefault(x => x.Username == username);
                Session[Constant.USER_INFO] = khachang;
                if (khachang == null)
                {
                    return View("Index");
                }
                else
                {
                    if (khachang.Password == password)
                    {
                        var usersession = new Login();
                        usersession.Username = username;
                        usersession.Password = password;

                        Session.Add(Constant.USER, usersession);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View("Index");
                    }
                }
            }
            catch
            {
                return View("Index");
            }
        }
    }
}