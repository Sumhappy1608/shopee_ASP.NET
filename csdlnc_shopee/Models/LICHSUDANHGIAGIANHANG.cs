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
    
    public partial class LICHSUDANHGIAGIANHANG
    {
        public string MAGIANHANG { get; set; }
        public string ID_NGUOIMUA { get; set; }
        public System.DateTime NGAYDANHGIA_GIANHANG { get; set; }
        public int SOSAO_GIANHANG { get; set; }
        public string NHANXET_GIANHANG { get; set; }
    
        public virtual GIANHANG GIANHANG { get; set; }
        public virtual THANHVIEN THANHVIEN { get; set; }
    }
}
