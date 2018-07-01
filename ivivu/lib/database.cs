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
            kh.maKH = DateTime.Now.Ticks;
            try
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
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
			if (name == "" || name == null) name = "null";
			if (district == "" || district == null) district = "null";
			if (street == "" || street == null) street = "null";
			if (city == "" || city == null) city = "null";
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
                var result = db.Database.SqlQuery<KhachSan>($"TimKhachSan {name}, {street}, {district}, {city}, {intStar}, {intPriceFrom}, {intPriceTo}"
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

		public List<Phong> timPhongTrongTheoNgay(string start, string end, string loaiPhong)
		{
			try
            {
				var result = db.Database.SqlQuery<Phong>($"TimPhongTrongTheoNgay \"{start}\", \"{end}\", \"{loaiPhong}\"");
                return result.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
		}

		public List<HoaDon> layTatCaHoaDon()
		{
			return db.HoaDons.Where(hd => hd.ngayThanhToan != null).ToList();
		}

		public HoaDon timHoaDon(string id)
		{
			return db.HoaDons.Find(id);
		}

        public bool themHoaDon(HoaDon hd)
        {
            try
            {
                db.HoaDons.Add(hd);
                db.SaveChanges();
                return true;
            } catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public DatPhong timPhieuDatPhong(string id)
        {
            return db.DatPhongs.Find(id);
        }

        public void datPhong(Int64 maKH, string maloaiPhong, DateTime start, DateTime end)
        {
            LoaiPhong loaiPhong = db.LoaiPhongs.Find(maloaiPhong);
            DatPhong datPhong = new DatPhong()
            {
                maDP = DateTime.Now.Ticks.ToString(),
                maKh = maKH,
                maLoaiPhong = maloaiPhong,
                ngayBatDau = start,
                ngayTraPhong = end,
                ngayDat = DateTime.Now,
                donGia = loaiPhong.donGia,
                moTa = loaiPhong.moTa,
                tinhTrang = "Chưa Thanh Toán"
            };
            db.DatPhongs.Add(datPhong);
            db.SaveChanges();
        }

        public void danhDauDatPhong(string maPhong, DateTime day, string TrangThai)
        {
            TrangThaiPhong trangThai = db.TrangThaiPhongs.Find(maPhong, day);
            if (trangThai != null)
            {
                trangThai.tinhTrang = TrangThai;
                db.SaveChanges();
            }
            else {
                trangThai = new TrangThaiPhong()
                {
                    maPhong = maPhong,
                    ngay = day,
                    tinhTrang = TrangThai
                };
                db.TrangThaiPhongs.Add(trangThai);
                db.SaveChanges();
            }
        }

        public List<DatPhong> getDanhSachDatPhong(Int64 maKH)
        {
            return db.DatPhongs.Where(dp => dp.maKh == maKH).ToList();
        }
    }
}
