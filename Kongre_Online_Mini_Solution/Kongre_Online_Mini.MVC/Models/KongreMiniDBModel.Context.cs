﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KongreOnlineMiniDBEntities : DbContext
    {
        public KongreOnlineMiniDBEntities()
            : base("name=KongreOnlineMiniDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aday> Aday { get; set; }
        public virtual DbSet<AdayOy> AdayOy { get; set; }
        public virtual DbSet<AdayYorum> AdayYorum { get; set; }
        public virtual DbSet<Bolge> Bolge { get; set; }
        public virtual DbSet<il> il { get; set; }
        public virtual DbSet<Mahal> Mahal { get; set; }
        public virtual DbSet<Oturum> Oturum { get; set; }
        public virtual DbSet<OyTuru> OyTuru { get; set; }
        public virtual DbSet<Secim> Secim { get; set; }
        public virtual DbSet<Teklif> Teklif { get; set; }
        public virtual DbSet<TeklifOy> TeklifOy { get; set; }
        public virtual DbSet<TeklifYorum> TeklifYorum { get; set; }
        public virtual DbSet<Ulke> Ulke { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<YorumTuru> YorumTuru { get; set; }
        public virtual DbSet<aspnet_Membership> aspnet_Membership { get; set; }
        public virtual DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public virtual DbSet<aspnet_Users> aspnet_Users { get; set; }
    }
}
