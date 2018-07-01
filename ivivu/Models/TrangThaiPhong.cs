using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ivivu.Models
{
    public class TrangThaiPhong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string maPhong { get; set; }

        [DataType(DataType.Date), Key]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime ngay { get; set; }

		public string tinhTrang { get; set; }
    }
}
