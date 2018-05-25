using System;
using System.ComponentModel.DataAnnotations;

namespace ivivu.Models
{
    public class KhachHang
    {
        [Key]
        public long maKh { get; set; }
        
        public String hoTen { get; set; }
        public String tenDangNhap { get; set; }
        public String matKhau { get; set; }

        public String soCMND { get; set; }
        public String diaChi { get; set; }
        public String soDienThoai { get; set; }

        public String moTa { get; set; }
    
        public String email { get; set; }
    }
}
