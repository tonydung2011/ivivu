using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ivivu.DAL;
using ivivu.lib;
using ivivu.Models;
using ivivu.role;
using ivivu.filters;

namespace ivivu.Controllers
{
    public class AdminController : Controller
    {
        [AdminAuthenticationFilter]
        public ActionResult Index()
        {
            return View ();
        }



        public ActionResult dang_nhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult dang_nhap(string tenDangNhap, string matKhau)
        {
            IvivuContext db = new IvivuContext();
            hash hash = new hash();
            Admin ketquaAdmin = db.Admins.Where(ad => (ad.tenDangNhap == tenDangNhap && ad.matKhau == matKhau)).FirstOrDefault();
            if (ketquaAdmin != null)
            {
                Session["AdminID"] = Guid.NewGuid();
                Session["User"] = tenDangNhap;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("dang_nhap", "Admin");
            }
        }

        [HttpPost]
        public ActionResult dang_xuat()
        {
            Session.Abandon();
            return RedirectToAction("dang_nhap", "Admin");
        }
    }
}
