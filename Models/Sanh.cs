using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNC.Models
{
    public class Sanh
    {
        [Key]
        public int SanhID { get; set; }
        [Required]
        [DisplayName("Tên Sảnh")]
        public string TenSanh { get; set; }
        [Required]
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
        [DisplayName("Hình Sảnh")]
        public string HinhSanh { get; set; }
    }
}