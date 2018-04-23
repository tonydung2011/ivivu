using System;
using System.ComponentModel.DataAnnotations;

namespace ivivu.Models
{
    public class TrangThaiPhong
    {
        [Key]
        public string maPhong { get; set; }

        [DataType(DataType.Date), Key]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime ngay { get; set; }

		public string tinhTrang { get; set; }
    }
}
