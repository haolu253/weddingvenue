using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNC.Models
{
    public class DichVu
    {
        [Key]
        public int DichVuID { get; set; }
        [Required]
        [DisplayName("Tên dịch vụ")]
        public string TenDichVu { get; set; }
        [Required]
        [DisplayName("Thông tin")]
        public string HinhThuc { get; set; }
        [Required]
        [DisplayName("Giá dịch vụ")]
        public int GiaDichVu { get; set; }
        [DisplayName("Hình ảnh")]
        public string HinhDichVu { get; set; }
    }
}