using System;
using System.ComponentModel.DataAnnotations;

namespace ivivu.Models
{
    public class Admin
    {   
        [Key]
        public string tenDangNhap { get; set; }
        public string matKhau { get; set; }
    }
}
