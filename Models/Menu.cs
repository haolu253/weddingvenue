using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNC.Models
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        [Required]
        [DisplayName("Thực đơn")]
        public string TenMenu { get; set; }
    }
}