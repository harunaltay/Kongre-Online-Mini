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
    
    public partial class AdayYorum
    {
        public int AdayYorumId { get; set; }
        public int AdayId { get; set; }
        public System.Guid UyeId { get; set; }
        public System.DateTime Tarih { get; set; }
        public System.TimeSpan Saat { get; set; }
        public int YorumTuruId { get; set; }
        public string Metin { get; set; }
    
        public virtual Aday Aday { get; set; }
        public virtual Uye Uye { get; set; }
        public virtual YorumTuru YorumTuru { get; set; }
    }
}
