﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceFull
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UsuariosEntities : DbContext
    {
        public UsuariosEntities()
            : base("name=UsuariosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<preferencia> preferencias { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
        public virtual DbSet<usuario_preferencias> usuario_preferencias { get; set; }
    }
}
