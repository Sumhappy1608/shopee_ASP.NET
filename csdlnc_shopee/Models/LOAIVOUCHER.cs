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
    
    public partial class LOAIVOUCHER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIVOUCHER()
        {
            this.VOUCHERs = new HashSet<VOUCHER>();
        }
    
        public string MALOAIVOUCHER { get; set; }
        public string TENLOAIVOUCHER { get; set; }
        public string DIEUKIEN { get; set; }
        public string LOAIGIAM { get; set; }
        public decimal MUCGIA { get; set; }
        public int UUDAI { get; set; }
        public decimal GIAMTOIDA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VOUCHER> VOUCHERs { get; set; }
    }
}
