﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RapidoHR.WebApi.Repository.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RapidoERP_KMBEntities : DbContext
    {
        public RapidoERP_KMBEntities()
            : base("name=RapidoERP_KMBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EmpDesignation> EmpDesignations { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<EmpPayroll> EmpPayrolls { get; set; }
    }
}
