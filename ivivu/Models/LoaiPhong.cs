using System;
using System.ComponentModel.DataAnnotations;

namespace ivivu.Models
{
    public class LoaiPhong
    {
        [Key]
        public string maLoaiPhong { get; set; }
        
		public string tenLoaiPhong { get; set; }
		public string maKS { get; set; }

		public int donGia { get; set; }

		public string moTa { get; set; }
		public int slTrong { get; set; }
    }
}
