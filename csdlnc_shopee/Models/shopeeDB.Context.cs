﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace csdlnc_shopee.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class shopeeEntities3 : DbContext
    {
        public shopeeEntities3()
            : base("name=shopeeEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DANHMUC> DANHMUCs { get; set; }
        public virtual DbSet<DATHANG> DATHANGs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<DONMUA> DONMUAs { get; set; }
        public virtual DbSet<DONVIVANCHUYEN> DONVIVANCHUYENs { get; set; }
        public virtual DbSet<GIANHANG> GIANHANGs { get; set; }
        public virtual DbSet<GIOHANG> GIOHANGs { get; set; }
        public virtual DbSet<HANGHOA> HANGHOAs { get; set; }
        public virtual DbSet<LICHSUDANHGIAGIANHANG> LICHSUDANHGIAGIANHANGs { get; set; }
        public virtual DbSet<LICHSUDANHGIAHANGHOA> LICHSUDANHGIAHANGHOAs { get; set; }
        public virtual DbSet<LICHSUXEMHANGHOA> LICHSUXEMHANGHOAs { get; set; }
        public virtual DbSet<LOAIVOUCHER> LOAIVOUCHERs { get; set; }
        public virtual DbSet<NGANHHANG> NGANHHANGs { get; set; }
        public virtual DbSet<TAIKHOANDANGNHAP> TAIKHOANDANGNHAPs { get; set; }
        public virtual DbSet<THANHTOAN> THANHTOANs { get; set; }
        public virtual DbSet<THANHVIEN> THANHVIENs { get; set; }
        public virtual DbSet<THONGTINDONHANG> THONGTINDONHANGs { get; set; }
        public virtual DbSet<THONGTINVANCHUYEN> THONGTINVANCHUYENs { get; set; }
        public virtual DbSet<VOUCHER> VOUCHERs { get; set; }
        public virtual DbSet<VOUCHER_NGUOIDUNG> VOUCHER_NGUOIDUNG { get; set; }
    }
}
