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
    
    public partial class OyTuru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OyTuru()
        {
            this.AdayOy = new HashSet<AdayOy>();
            this.TeklifOy = new HashSet<TeklifOy>();
        }
    
        public int OyTuruId { get; set; }
        public string OyTuruAdi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdayOy> AdayOy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeklifOy> TeklifOy { get; set; }
    }
}
