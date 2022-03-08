using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace WebNC.Models
{
    public class MonAn
    {
        [Key]
        public int MonAnID { get; set; }
        [Required]
        [DisplayName("Tên món")]
        public string TenMonAn { get; set; }
        [Required]
        [DisplayName("Giá")]
        public int GiaMonAn { get; set; }
        [DisplayName("Hình ảnh")]
        public string HinhMonAn { get; set; }
        [ForeignKey("Menu")]
        
        public Nullable<int> MenuID { get; set; }
        public virtual Menu Menu { get; set; }
    }
}