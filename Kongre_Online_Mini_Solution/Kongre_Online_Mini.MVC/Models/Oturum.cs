//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kongre_Online_Mini.MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Oturum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oturum()
        {
            this.Secim = new HashSet<Secim>();
            this.Teklif = new HashSet<Teklif>();
        }
    
        public int OturumId { get; set; }
        public int MahalId { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<System.TimeSpan> Saat { get; set; }
        public string Konu { get; set; }
        public string Metin { get; set; }
    
        public virtual Mahal Mahal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Secim> Secim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Teklif> Teklif { get; set; }
    }
}