using System;
using System.ComponentModel.DataAnnotations;

namespace ivivu.Models
{
    public class KhachSan
    {
        [Key]
        public string MaKS { get; set; }
        
        public string tenKS { get; set; }
        public int soSao { get; set; }
        public string soNha { get; set; }
        public string duong { get; set; }
        public string quan { get; set; }
        public string thanhPho { get; set; }

        [DataType(DataType.Currency)]
        public object giaTB { get; set; }

        public string moTa { get; set; }
    }
}
