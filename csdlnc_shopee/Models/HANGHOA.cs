//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class HANGHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANGHOA()
        {
            this.DONHANGs = new HashSet<DONHANG>();
            this.GIOHANGs = new HashSet<GIOHANG>();
            this.LICHSUDANHGIAHANGHOAs = new HashSet<LICHSUDANHGIAHANGHOA>();
            this.LICHSUXEMHANGHOAs = new HashSet<LICHSUXEMHANGHOA>();
        }
    
        public string MAHANGHOA { get; set; }
        public string TENHANGHOA { get; set; }
        public string MOTA { get; set; }
        public decimal GIATHANH { get; set; }
        public int SOLUONGTON { get; set; }
        public string LOAIHANGHOA { get; set; }
        public string HHFlag { get; set; }
        public double DANHGIA_HANGHOA { get; set; }
        public Nullable<System.DateTime> THOIHANSUDUNG { get; set; }
        public int SOLUONGDABAN { get; set; }
        public string MAGIANHANG { get; set; }
        public System.DateTime NGAYDANG { get; set; }
        public string HINHANH { get; set; }
    
        public virtual DANHMUC DANHMUC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
        public virtual GIANHANG GIANHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIOHANG> GIOHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHSUDANHGIAHANGHOA> LICHSUDANHGIAHANGHOAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHSUXEMHANGHOA> LICHSUXEMHANGHOAs { get; set; }
    }
}
