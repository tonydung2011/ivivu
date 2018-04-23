using System;
using System.ComponentModel.DataAnnotations;

namespace ivivu.Models
{
    public class HoaDon
    {
        [Key]
        public string maHD { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime ngayThanhToan { get; set; }

        [DataType(DataType.Currency)]
		public int tongTien { get; set; }

		public string maDP { get; set; }
    }
}
