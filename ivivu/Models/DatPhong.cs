using System;
using System.ComponentModel.DataAnnotations;

namespace ivivu.Models
{
    public class DatPhong
    {
        [Key]
        public string maDP { get; set; }

        public string maLoaiPhong { get; set; }
        public string maKh { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ngayBatDau { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ngayTraPhong { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ngayDat { get; set; }

        [DataType(DataType.Currency)]
        public object donGia { get; set; }

        public string moTa  { get; set; }
        public string tinhTrang  { get; set; }
    }
}
