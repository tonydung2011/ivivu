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
        [UserAuthenticationFilter]
        public ActionResult index()
        {
            IvivuContext db = new IvivuContext();
            KhachHang kh = db.KhachHangs.where(kh => kh.tenDangNhap = HttpContext.User.Identity.Name).FirstOrDefault();
            return View(kh);
        }

        public ActionResult dang_ky()
        {
            return View();
        }

        [HttpPost]
        public ActionResult dang_ky(Models.KhachHang KhachHangData)
        {
            IvivuContext db = new IvivuContext();
            hash h = new hash();
            DateTime now = DateTime.Now;
            try
            {
                db.KhachHangs.Add(new KhachHang()
                {
                    maKh = "KH" + now.ToString(),
                    hoTen = KhachHangData.hoTen,
                    tenDangNhap = KhachHangData.tenDangNhap,
                    matKhau = KhachHangData.matKhau,
                    soCMND = KhachHangData.soCMND,
                    diaChi = KhachHangData.diaChi,
                    soDienThoai = KhachHangData.soDienThoai,
                    email = KhachHangData.email
                });
                db.SaveChanges();
                return RedirectToAction("dang_nhap", "KhachHang");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RedirectToAction("dang_ky", "KhachHang");
            }
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
            KhachHang ketquaKH = db.KhachHangs.Where(kh => (kh.tenDangNhap == tenDangNhap && kh.matKhau == matKhau)).FirstOrDefault();
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
