using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ivivu.DAL;
using ivivu.Models;

namespace ivivu.lib
{
    public class database
    {
        private IvivuContext db;
        public database()
        {
            db = new IvivuContext();  
        }

        public KhachSan timKhachSan(string id)
        {
            return db.KhachSans.Find(id);
        }

        public bool xoaKhachSan(string id)
        {
            try
            {
                KhachSan ks = db.KhachSans.Find(id);
                db.KhachSans.Remove(ks);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool thenKhachSan(KhachSan ks)
        {
            ks.MaKS = "KS" + DateTime.Now.Ticks.ToString();
            try
            {
                db.KhachSans.Add(ks);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool chinhSuaKhachSan(string id, KhachSan ks)
        {
            KhachSan kq = db.KhachSans.Find(id);
            if (kq != null) db.KhachSans.Remove(kq);
            try
            {
                db.KhachSans.Add(ks);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public KhachHang timKhachHang(string tenDangNhap, string matKhau)
        {
            return db.KhachHangs.Where(kh => (kh.tenDangNhap == tenDangNhap && kh.matKhau == matKhau)).FirstOrDefault();
        }

        public KhachHang timKhachHang(string id)
        {
            return db.KhachHangs.Find(id);
        }

        public KhachHang timKhachHangTheoTenDangNhap(string tenDangNhap)
        {
            return db.KhachHangs.Where(kh => (kh.tenDangNhap == tenDangNhap)).FirstOrDefault();
        }

        public bool themKhachHang(KhachHang kh)
        {
            kh.maKh = "KH" + DateTime.Now.Ticks.ToString();
            try
            {
                db.KhachHangs.Add(kh);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public QuanTri timQuanTri(string tenDangNhap, string matKhau)
        {
            return db.QuanTris.Where(ad => (ad.tenDangNhap == tenDangNhap && ad.matKhau == matKhau)).FirstOrDefault();
        }

        public LoaiPhong timLoaiPhong(string id)
        {
            return db.LoaiPhongs.Find(id);
        }
    }
}
