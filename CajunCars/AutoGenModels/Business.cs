﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CajunCars.AutoGenModels
{
    public partial class Business : DbContext
    {
        public Business()
        {
        }

        public Business(DbContextOptions<Business> options)
            : base(options)
        {
        }

        public virtual DbSet<Commission> Commissions { get; set; }
        public virtual DbSet<Dealership> Dealerships { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<SoldVehicle> SoldVehicles { get; set; }
        public virtual DbSet<StoredVehicle> StoredVehicles { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Filename=..\\cajunCars.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<SoldVehicle>()
                .HasKey(b => b.Vin);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
