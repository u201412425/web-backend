﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoggyStyleWS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DoggyStyleEntities : DbContext
    {
        public DoggyStyleEntities()
            : base("name=DoggyStyleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdoptionRequest> AdoptionRequest { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<PetAdoption> PetAdoption { get; set; }
        public virtual DbSet<PetImage> PetImage { get; set; }
        public virtual DbSet<PetShelter> PetShelter { get; set; }
        public virtual DbSet<PetShelterImage> PetShelterImage { get; set; }
        public virtual DbSet<PetShelterLocal> PetShelterLocal { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}