using System;
using System.ComponentModel.DataAnnotations;

namespace ivivu.Models
{
    public class KhachHang
    {
        [Key]
        public String maKh { get; set; }
        
        public String hoTen { get; set; }
        public String tenDangNhap { get; set; }

        [DataType(DataType.Password)]
        public object matKhau { get; set; }

        public String soCMND { get; set; }
        public String diaChi { get; set; }

        [DataType(DataType.PhoneNumber)]
        public object soDienThoai { get; set; }

        public String moTa { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public object email { get; set; }
    }
}
