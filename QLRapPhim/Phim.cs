//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLRapPhim
{
    using System;
    using System.Collections.Generic;
    
    public partial class Phim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phim()
        {
            this.LichChieux = new HashSet<LichChieu>();
        }
    
        public string id { get; set; }
        public string idTheLoai { get; set; }
        public string TenPhim { get; set; }
        public string MoTa { get; set; }
        public double ThoiLuong { get; set; }
        public string HangPhim { get; set; }
        public string DaoDien { get; set; }
        public string DienVien { get; set; }
        public System.DateTime NgayCongChieu { get; set; }
        public byte[] ApPhich { get; set; }
        public string Trailer { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichChieu> LichChieux { get; set; }
        public virtual TheLoai TheLoai { get; set; }
    }
}