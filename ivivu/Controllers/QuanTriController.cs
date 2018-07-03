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
    public class QuanTriController : Controller
    {
        private database ivivuDB;

        public QuanTriController()
        {
            ivivuDB = new database();
        }

        [QuanTriAuthenticationFilter]
        public ActionResult index()
        {
			return RedirectToAction("dang_nhap", "QuanTri");
        }

        public ActionResult dang_nhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult dang_nhap(string tenDangNhap, string matKhau)
        {
            QuanTri ketquaQuanTri = ivivuDB.timQuanTri(tenDangNhap, matKhau);
            if (ketquaQuanTri != null)
            {
                Session["QuanTriID"] = Guid.NewGuid();
                Session["User"] = tenDangNhap;
                return RedirectToAction("thong_ke_hoa_don", "QuanTri");
            }
            else
            {
                return RedirectToAction("dang_nhap", "QuanTri");
            }
        }

        [HttpPost]
        public ActionResult dang_xuat()
        {
            Session.Abandon();
            return RedirectToAction("dang_nhap", "QuanTri");
        }

		[QuanTriAuthenticationFilter]
		public ActionResult thong_ke()
		{
			return View();
		}

		[QuanTriAuthenticationFilter]
        public ActionResult thong_ke_hoa_don()
        {
            return View();
        }

        [QuanTriAuthenticationFilter]
        public ActionResult thong_ke_dat_phong()
        {
            return View();
        }

        [QuanTriAuthenticationFilter, HttpPost]
        public ActionResult them_hoa_don(string maDP)
        {
            DatPhong datPhong = ivivuDB.timPhieuDatPhong(maDP);
            ivivuDB.confirmDatPhong(maDP);
            if (datPhong != null)
            {
                DateTime endDay = DateTime.Now, StartDay = DateTime.Now;
                DateTime.TryParse(datPhong.ngayTraPhong.ToString(), out endDay);
                DateTime.TryParse(datPhong.ngayBatDau.ToString(), out StartDay);
                HoaDon hoaDon = new HoaDon()
                {
                    ngayThanhToan = DateTime.Now,
                    tongTien = datPhong.donGia * (endDay - StartDay).Days,
                    maDP = maDP,
                    maHD = DateTime.Now.Ticks.ToString()
                };
                bool success = ivivuDB.themHoaDon(hoaDon);
                if (success)
                {
                    return RedirectToAction("thong_ke_hoa_don");
                }
            }
            return RedirectToAction("thong_ke_dat_phong");
        }
    }
}
