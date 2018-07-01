using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ivivu.Models
{
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 maKH { get; set; }
        
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
