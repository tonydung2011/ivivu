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

        // hien thi giao dien them khach san moi
        [AdminAuthenticationFilter]
        public ActionResult them_khach_san()
        {
            return View ();
        }

        // logic xu ly them khach san moi khi admin bam nut tao - co post method
        [AdminAuthenticationFilter, HttpPost]
        public ActionResult them_khach_san(KhachSan KhachSanData)
        {
            // tuong tu them Khach hang dang ky
            return RedirectToAction("Index", "Admin");
        }

        // liet ke toan bo danh sach cac khach san trong db
        [AdminAuthenticationFilter]
        public ActionResult danh_sach_khach_san()
        {
            return View ();
        }

        // thong tin chi tiet 1 khach san
        [AdminAuthenticationFilter]
        public ActionResult thong_tin_khach_san(string IdKS)
        {
            IvivuContext db = new IvivuContext();
            KhachSan KS = db.KhachSans.Where(ks => ks.MaKS == IdKS).FirstOrDefault();
            return View (KS);
        }

        // logic xu ly xoa 1 khach san
        [AdminAuthenticationFilter]
        public ActionResult xoa_khach_san(string IdKS)
        {
            IvivuContext db = new IvivuContext();
            KhachSan ks = db.KhachSans.Find(IdKS);
            db.KhachSans.Remove(ks);
            return RedirectToAction("Index", "Admin");
        }

        // hien thi giao dien chinh sua thong tin cua 1 khach san
        [AdminAuthenticationFilter]
        public ActionResult chinh_sua_khach_san(string IdKS)
        {
            IvivuContext db = new IvivuContext();
            KhachSan KS = db.KhachSans.Where(ks => ks.MaKS == IdKS).FirstOrDefault();
            return View ();
        }

        // logic xu ly chinh sua thong tin 1 khach san - co post method
        [AdminAuthenticationFilter, HttpPost]
        public ActionResult chinh_sua_khach_san(string IdKS, KhachSan KhachSanData)
        {
            IvivuContext db = new IvivuContext();
            KhachSan KS = db.KhachSans.Where(ks => ks.MaKS == IdKS).FirstOrDefault();
            db.KhachSans.Remove(KS);
            db.KhachSans.Add(KhachSanData);
            return View ();
        }

        // phan them loai phong tuong tu nhu them khach san

        [AdminAuthenticationFilter]
        public ActionResult them_loai_phong()
        {
            return View ();
        }

        [AdminAuthenticationFilter, HttpPost]
        public ActionResult them_loai_phong()
        {
            return RedirectToAction("Index", "Admin");
        }

        [AdminAuthenticationFilter]
        public ActionResult danh_sach_loai_phong()
        {
            return View ();
        }

        [AdminAuthenticationFilter]
        public ActionResult xoa_loai_phong()
        {
            return View ();
        }

        [AdminAuthenticationFilter, HttpPost]
        public ActionResult xoa_loai_phong()
        {
            return RedirectToAction("Index", "Admin");
        }

        [AdminAuthenticationFilter]
        public ActionResult thong_tin_loai_phong(string IdLP)
        {
            return View();
        }

        [AdminAuthenticationFilter]
        public ActionResult chinh_sua_loai_phong()
        {
            return View();
        }

        [AdminAuthenticationFilter, HttpPost]
        public ActionResult chinh_sua_loai_phong()
        {
            return RedirectToAction("Index", "Admin");
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
