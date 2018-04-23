using System;
using System.ComponentModel.DataAnnotations;

namespace ivivu.Models
{
    public class Phong
    {
        [Key]
        public string maPhong { get; set; }
        
		public string loaiPhong { get; set; }
		public int soPhong { get; set; }
    }
}
