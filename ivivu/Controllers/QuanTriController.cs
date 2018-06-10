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

        // hien thi giao dien them khach san moi
        [QuanTriAuthenticationFilter]
        public ActionResult them_khach_san()
        {
            return View ();
        }

        // logic xu ly them khach san moi khi QuanTri bam nut tao - co post method
        [QuanTriAuthenticationFilter, HttpPost]
        public ActionResult them_khach_san(KhachSan KhachSanData)
        {
            bool temp = ivivuDB.thenKhachSan(KhachSanData);
            if (!temp) return RedirectToAction("them_khach_san", "QuanTri");
            return RedirectToAction("Index", "QuanTri");
        }

        // liet ke toan bo danh sach cac khach san trong db
        [QuanTriAuthenticationFilter]
        public ActionResult danh_sach_khach_san()
        {
            return View ();
        }

        // thong tin chi tiet 1 khach san
        [QuanTriAuthenticationFilter]
        public ActionResult thong_tin_khach_san(string IdKS)
        {
            KhachSan KS = ivivuDB.timKhachSan(IdKS);
            return View (KS);
        }

        // logic xu ly xoa 1 khach san
        [QuanTriAuthenticationFilter, HttpPost]
        public ActionResult xoa_khach_san(string IdKS)
        {
            bool temp = ivivuDB.xoaKhachSan(IdKS);
            if (!temp) return RedirectToAction("danh_sach_khach_san", "QuanTri");
            return RedirectToAction("Index", "QuanTri");
        }

        // hien thi giao dien chinh sua thong tin cua 1 khach san
        [QuanTriAuthenticationFilter]
        public ActionResult chinh_sua_khach_san(string IdKS)
        {
            KhachSan KS = ivivuDB.timKhachSan(IdKS);
            return View (KS);
        }

        // logic xu ly chinh sua thong tin 1 khach san - co post method
        [QuanTriAuthenticationFilter, HttpPost]
        public ActionResult chinh_sua_khach_san(string IdKS, KhachSan KhachSanData)
        {
            bool temp = ivivuDB.chinhSuaKhachSan(IdKS, KhachSanData);
            if (temp) return RedirectToAction("thong_tin_khach_san", "QuanTri", IdKS);
            return RedirectToAction("chinh_sua_khach_san", "QuanTri");
        }

        // phan them loai phong tuong tu nhu them khach san

        [QuanTriAuthenticationFilter]
        public ActionResult them_loai_phong()
        {
            return View ();
        }

        [QuanTriAuthenticationFilter, HttpPost]
        public ActionResult them_loai_phong(LoaiPhong loaiPhongData)
        {
            return RedirectToAction("Index", "QuanTri");
        }

        [QuanTriAuthenticationFilter]
        public ActionResult danh_sach_loai_phong()
        {
            return View ();
        }

        [QuanTriAuthenticationFilter, HttpPost]
        public ActionResult xoa_loai_phong(string IdLP)
        {
            return RedirectToAction("Index", "QuanTri");
        }

        [QuanTriAuthenticationFilter]
        public ActionResult thong_tin_loai_phong(string IdLP)
        {
            return View();
        }

        [QuanTriAuthenticationFilter]
        public ActionResult chinh_sua_loai_phong()
        {
            return View();
        }

        [QuanTriAuthenticationFilter, HttpPost]
        public ActionResult chinh_sua_loai_phong(string IdLP, LoaiPhong loaiPhongData)
        {
            return RedirectToAction("Index", "QuanTri");
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
