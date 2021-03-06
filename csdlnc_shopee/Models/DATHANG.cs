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
    
    public partial class DATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATHANG()
        {
            this.DONMUAs = new HashSet<DONMUA>();
            this.DONHANGs = new HashSet<DONHANG>();
            this.THANHTOANs = new HashSet<THANHTOAN>();
            this.THONGTINDONHANGs = new HashSet<THONGTINDONHANG>();
        }
    
        public string ID_DONHANG { get; set; }
        public string NGUOIMUA { get; set; }
        public string GIANHANG { get; set; }
        public System.DateTime NGAYDAT { get; set; }
        public decimal TONGTIEN { get; set; }
        public string MADVVC { get; set; }
    
        public virtual GIANHANG GIANHANG1 { get; set; }
        public virtual DONVIVANCHUYEN DONVIVANCHUYEN { get; set; }
        public virtual THANHVIEN THANHVIEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONMUA> DONMUAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHTOAN> THANHTOANs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THONGTINDONHANG> THONGTINDONHANGs { get; set; }
    }
}
