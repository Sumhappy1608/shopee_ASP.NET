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
    
    public partial class VOUCHER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VOUCHER()
        {
            this.THANHTOANs = new HashSet<THANHTOAN>();
            this.VOUCHER_NGUOIDUNG = new HashSet<VOUCHER_NGUOIDUNG>();
            this.GIANHANGs = new HashSet<GIANHANG>();
            this.NGANHHANGs = new HashSet<NGANHHANG>();
        }
    
        public string MACODE { get; set; }
        public System.DateTime THOIGIANAPDUNG { get; set; }
        public string LOAIVOUCHER { get; set; }
    
        public virtual LOAIVOUCHER LOAIVOUCHER1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHTOAN> THANHTOANs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VOUCHER_NGUOIDUNG> VOUCHER_NGUOIDUNG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIANHANG> GIANHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGANHHANG> NGANHHANGs { get; set; }
    }
}
