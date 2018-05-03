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
    public class KhachHangController : Controller
    {
        private database ivivuDB;
        public KhachHangController()
        {
            ivivuDB = new database();
        }

        [UserAuthenticationFilter]
        public ActionResult index()
        {
            KhachHang kh = ivivuDB.timKhachHangTheoTenDangNhap(HttpContext.User.Identity.Name);
            return View(kh);
        }

        public ActionResult dang_ky()
        {
            return View();
        }

        [HttpPost]
        public ActionResult dang_ky(Models.KhachHang KhachHangData)
        {
           bool temp = ivivuDB.themKhachHang(KhachHangData);
           if (temp) return RedirectToAction("dang_nhap", "KhachHang");
           return RedirectToAction("dang_ky", "KhachHang");
        }

        public ActionResult dang_nhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult dang_nhap(string tenDangNhap, string matKhau)
        {
            KhachHang ketquaKH = ivivuDB.timKhachHang(tenDangNhap, matKhau);
            if (ketquaKH != null) {
                Session["UserID"] = Guid.NewGuid();
                Session["User"] = tenDangNhap;
                return RedirectToAction("index", "KhachHang");
            } else {
                return RedirectToAction("dang_nhap", "KhachHang");
            }
        }

        [HttpPost]
        public ActionResult dang_xuat()
        {
            Session.Abandon();
            return RedirectToAction("dang_nhap", "KhachHang");
        }
    }
}
