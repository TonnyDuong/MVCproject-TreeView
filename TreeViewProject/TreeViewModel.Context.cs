﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TreeViewProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CityInfoDBEntities : DbContext
    {
        public CityInfoDBEntities()
            : base("name=CityInfoDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<MenuSite> MenuSites { get; set; }
        public virtual DbSet<PointsOfInterest> PointsOfInterests { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
    }
}
