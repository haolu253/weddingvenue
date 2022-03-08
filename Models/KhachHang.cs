using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNC.Models
{
    public class KhachHang
    {
        [Key]
        public int KhachID { get; set; }
        [Required]
        [DisplayName("Tên Khách hàng")]
        public string TenKhach { get; set; }
        [Required]
        [DisplayName("Số ĐT")]
        public int SDT { get; set; }
        [Required]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}