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
    
    public partial class Teklif
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teklif()
        {
            this.TeklifOy = new HashSet<TeklifOy>();
            this.TeklifYorum = new HashSet<TeklifYorum>();
        }
    
        public int TeklifId { get; set; }
        public System.Guid UyeId { get; set; }
        public int OturumId { get; set; }
        public System.DateTime Tarih { get; set; }
        public System.TimeSpan Saat { get; set; }
        public string Metin { get; set; }
    
        public virtual Oturum Oturum { get; set; }
        public virtual Uye Uye { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeklifOy> TeklifOy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeklifYorum> TeklifYorum { get; set; }
    }
}
