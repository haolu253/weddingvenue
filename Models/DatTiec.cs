using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace WebNC.Models
{
    public class DatTiec
    {
        [Key]
        public int TiecID { get; set; }
        [Required]
        [DisplayName("Tên Chú rể")]
        public string ChuRe { get; set; }
        [Required]
        [DisplayName("Tên Cô dâu")]
        public string CoDau { get; set; }
        [DisplayName("Ngày đặt")]
        public DateTime NgayDat { get; set; }
        [Required]
        [DisplayName("Số bàn")]
        [Range(1,999)]
        public int SoBan { get; set; }
        [DisplayName("Giá tiệc")]
        public int GiaTiec { get; set; }
        [ForeignKey("Menu")]
        public int MenuID { get; set; }
        public virtual Menu Menu { get; set; }
        [ForeignKey("Sanh")]
        public int SanhID { get; set; }
        public virtual Sanh Sanh{ get; set; }
        [ForeignKey("KhachHang")]
        public int KhachID { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        [ForeignKey("DichVu")]
        public int DichVuID { get; set; }
        public virtual DichVu DichVu { get; set; }
    }
}