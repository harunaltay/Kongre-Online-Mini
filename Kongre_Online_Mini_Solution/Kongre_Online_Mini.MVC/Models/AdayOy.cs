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
    
    public partial class AdayOy
    {
        public int AdayOyId { get; set; }
        public int AdayId { get; set; }
        public System.Guid UyeId { get; set; }
        public int OyTuruId { get; set; }
        public System.DateTime Tarih { get; set; }
        public System.TimeSpan Saat { get; set; }
    
        public virtual Aday Aday { get; set; }
        public virtual OyTuru OyTuru { get; set; }
        public virtual Uye Uye { get; set; }
    }
}
