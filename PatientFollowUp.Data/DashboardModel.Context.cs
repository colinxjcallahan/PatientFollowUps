﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatientFollowUp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DashboardEntities : DbContext
    {
        public DashboardEntities()
            : base("name=DashboardEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FollowUp> FollowUps { get; set; }
        public virtual DbSet<FollowUpStatu> FollowUpStatus { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<FollowUpWithSynonymData> FollowUpWithSynonymDatas { get; set; }
        public virtual DbSet<FollowUpClosedReason> FollowUpClosedReasons { get; set; }
        public virtual DbSet<FacilityType> FacilityTypes { get; set; }
    }
}
