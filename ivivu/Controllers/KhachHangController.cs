using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult post_dang_ky(string hoTen, string tenDangNhap, string matKhau, string soCMND, string soDienThoai, string email, string moTa)
        {
            
            return View();
        }
    }
}
