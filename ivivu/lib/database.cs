using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ivivu.DAL;
using ivivu.Models;
using System.Data.SqlClient;
using System.Data.Objects;
using System.Data;
using System.Data.Entity;

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
            kh.maKh = DateTime.Now.Ticks;
            try
            {
				db.Database.ExecuteSqlCommand("ThemKhachHang @maKH, @hoTen, @tenDangNhap, @matKhau, @soCMND, @diaChi, @soDienThoai, @moTa, @email",
											  new SqlParameter("@maKH", kh.maKh),
											  new SqlParameter("@hoTen", kh.hoTen),
											  new SqlParameter("@tenDangNhap", kh.tenDangNhap),
											  new SqlParameter("@matKhau", kh.matKhau),
											  new SqlParameter("@soCMND", kh.soCMND),
											  new SqlParameter("@diaChi", kh.diaChi),
											  new SqlParameter("@soDienThoai", kh.soDienThoai),
											  new SqlParameter("@moTa", kh.moTa),
											  new SqlParameter("@email", kh.email)
											 );
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

		public List<KhachSan> timKhachSanTheoYeuCau(string name, string district, string street, string city, string priceFrom, string priceTo, string star, string takeFrom)
		{
			int temp, intPriceFrom, intPriceTo, intStar, intFrom = 0;
            if (Int32.TryParse(priceFrom, out temp)) {
				intPriceFrom = temp;
			} else {
				intPriceFrom = 0;
			}
			if (Int32.TryParse(priceTo, out temp)) {
				intPriceTo = temp;
			} else {
				intPriceTo = 100000000;
			}
			if (Int32.TryParse(star, out temp)) {
				intStar = temp;
			} else {
				intStar = 0;
			}
			if (name == "") name = null;
			if (district == "") district = null;
			if (street == "") street = null;
			if (city == "") city = null;
			if (takeFrom != "") 
			{
				if (Int32.TryParse(takeFrom, out temp))
                {
                    intFrom = temp;
                }
                else
                {
                    intFrom = 0;
                }
			}
			try {
				var result = db.Database.SqlQuery<KhachSan>("TimKhachSan @tenKS, @duong, @quan, @thanhpho, @sosao, @giaTu, @giaDen",
															 new SqlParameter("@tenKS", name),
															 new SqlParameter("@duong", street),
															 new SqlParameter("@quan", district),
															 new SqlParameter("@thanhPho", city),
															 new SqlParameter("@soSao", intStar),
															 new SqlParameter("@giaTu", intPriceFrom),
															 new SqlParameter("@giaDen", intPriceTo)
				                                           ).Take(20).Skip(intFrom);
				return result.ToList();
            } catch (Exception e) {
				Console.WriteLine(e.ToString());
				return null;
            }
		}

		public List<LoaiPhong> timLoaiPhongTheoKhachSan(string id)
		{
			return db.LoaiPhongs.Where(lp => (lp.maKS == id)).ToList();
		}

		public List<Phong> timPhongTheoLoaiPhong(string id)
		{
			return db.Phongs.Where(p => (p.loaiPhong == id)).ToList();
		}

		public List<Phong> timPhongTrongTheoNgay(DateTime start, DateTime end, string loaiPhong)
		{
			try
            {
				var startDate = new SqlParameter("@start", SqlDbType.Date, 60);
				startDate.Direction = ParameterDirection.Input;
				start = DateTime.ParseExact(start.ToString(), "yyyy-mm-dd hh:mm:ss.fff", null);
				startDate.Value = start;
                var endDate = new SqlParameter("@end", end.Date);
				endDate.Direction = ParameterDirection.Input;
                end = DateTime.ParseExact(end.ToString(), "yyyy-mm-dd hh:mm:ss.fff", null);
                endDate.Value = end;
				var result = db.Database.SqlQuery<Phong>("TimPhongTrongTheoNgay @start, @end",startDate , endDate);
                return result.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
		}

		public IEnumerable<Object> layTatCaHoaDon()
		{
			return db.HoaDons.Where(hd => hd.ngayThanhToan != null);
		}

		public HoaDon timHoaDon(string id)
		{
			return db.HoaDons.Find(id);
		}
    }
}
