using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ivivu.Models;
using ivivu.DAL;

namespace ivivu.Controllers
{
    public class HomeController : Controller
    {
        private IvivuContext db = new IvivuContext();
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }
        public ActionResult test_db()
        {
            //db.KhachHangs.Add(new KhachHang()
            //{
            //    maKh = "123",
            //    hoTen = "tester",
            //    tenDangNhap = "tester-dang-nhap",
            //    matKhau = "12345678",
            //    soCMND = "127xxxxxxxx",
            //    diaChi = "Viet Nam",
            //    soDienThoai = "911",
            //    email = "email@gmail.com"
            //});
            //db.SaveChanges();
            KhachHang A = db.KhachHangs.Find("123");
            return View(A);
        }
    }
}
