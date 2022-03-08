using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebNC.Models
{
    public class CSDLContext : DbContext
    {
        public CSDLContext()
        {
            SqlConnectionStringBuilder sqlb = new SqlConnectionStringBuilder();
            sqlb.DataSource = "DESKTOP-PJBVRNN\\SQLEXPRESS";
            sqlb.InitialCatalog = "CSDLDoAnWebNC";
            sqlb.IntegratedSecurity = true;
            this.Database.Connection.ConnectionString = sqlb.ConnectionString;
        }
        public virtual DbSet<Sanh> Sanhs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MonAn> MonAns { get; set; }
        public virtual DbSet<DatTiec> DatTiecs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
    }
}