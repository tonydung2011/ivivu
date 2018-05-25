using System;
using System.Text;
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

		[UserAuthenticationFilter, HttpPost]
		public ActionResult tim_khach_san(string name, string district, string street, string city, string priceFrom, string priceTo, string star)
		{
			string didSearch = "true";
			return RedirectToAction("tim_khach_san", "KhachHang", new { name, district, street, city, priceFrom, priceTo, star, didSearch = didSearch});
		}

        [UserAuthenticationFilter]
		public ActionResult tim_khach_san(string name, string district, string street, string city, string priceFrom, string priceTo, string star, string didSearch, string takeFrom)
        {
			if (didSearch == "true") {
				List<KhachSan> khachSans;
                khachSans = ivivuDB.timKhachSanTheoYeuCau(name, district, street, city, priceFrom, priceTo, star, takeFrom);
				khachSans.ForEach((ks) =>
				{
					ks.tenKS = ks.tenKS.Normalize();
					ks.duong = ks.duong.Normalize();
					ks.quan = ks.quan.Normalize();
					ks.thanhPho = ks.thanhPho.Normalize();
				});
                return View(khachSans);				
			} else {
				return View();
			}
        }

		[UserAuthenticationFilter]
		public ActionResult thong_tin_khach_san(string id1)
		{
            KhachSan khachSan = ivivuDB.timKhachSan(id1);
			if (khachSan == null) return RedirectToAction("tim_khach_san", "KhachHang");
			ViewBag.roomClassColl = ivivuDB.timLoaiPhongTheoKhachSan(id1);
			return View(khachSan);
		}

		[UserAuthenticationFilter]
		public ActionResult dat_phong(string id1, string id2, DateTime start, DateTime end, string didbook)
		{
			if (didbook != "true") {
				KhachSan khachSan = ivivuDB.timKhachSan(id1);
                LoaiPhong loaiPhong = ivivuDB.timLoaiPhong(id2);
                ViewBag.idKS = id1;
                ViewBag.idLP = id2;
                return View(khachSan);
			} else {
				KhachSan khachSan = ivivuDB.timKhachSan(id1);
                LoaiPhong loaiPhong = ivivuDB.timLoaiPhong(id2);
                ViewBag.idKS = id1;
                ViewBag.idLP = id2;
				if (start.CompareTo(end) >= 0) {
					return RedirectToAction("dat_phong", "KhachHang", new { id1, id2});
				}
				List<Phong> listPhong = ivivuDB.timPhongTrongTheoNgay(start, end, id2);
                return View(khachSan);
			}
		}

		[UserAuthenticationFilter, HttpPost]
		public ActionResult dat_phong(string id1, string id2, DateTime startDay, DateTime endDay)
        {
			string didbook = "true";
			return RedirectToAction("dat_phong", "KhachHang", new { id1, id2, startDay, endDay, didbook });
        }
    }
}
