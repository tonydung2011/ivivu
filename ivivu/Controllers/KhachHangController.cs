using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ivivu.DAL;
using ivivu.lib;
using ivivu.Models;

namespace ivivu.Controllers
{
    public class KhachHangController : Controller
    {
        public ActionResult index()
        {
            return View();
        }

        public ActionResult dang_ky()
        {
            return View();
        }

        [HttpPost]
        public ActionResult post_dang_ky(Models.KhachHang KhachHangData)
        {
            IvivuContext db = new IvivuContext();
            hash h = new hash();
            string hashResult = h.hashSourceKey(KhachHangData.matKhau, KhachHangData.tenDangNhap, "KhachHang");
            db.KhachHangs.Add(new KhachHang()
            {
                maKh = hashResult,
                hoTen = KhachHangData.hoTen,
                tenDangNhap = KhachHangData.tenDangNhap,
                matKhau = KhachHangData.matKhau,
                soCMND = KhachHangData.soCMND,
                diaChi = KhachHangData.diaChi,
                soDienThoai = KhachHangData.soDienThoai,
                email = KhachHangData.email
            });
            db.SaveChanges();
            return View();
        }
    }
}
