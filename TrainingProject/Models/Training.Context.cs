﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TrainingEntities : DbContext
    {
        public TrainingEntities()
            : base("name=TrainingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Coin> Coins { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonCoin> PersonCoins { get; set; }
        public virtual DbSet<SpecialCoin> SpecialCoins { get; set; }
        public virtual DbSet<FriendGame> FriendGames { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Game> Games { get; set; }
    }
}
