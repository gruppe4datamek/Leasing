﻿namespace WebapiLeasing8
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LeasingDBContext : DbContext
    {
        public LeasingDBContext()
            : base("name=LeasingDBContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
            base.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Bil> Bils { get; set; }
        public virtual DbSet<Kunde> Kundes { get; set; }
        public virtual DbSet<Leasing> Leasings { get; set; }
        public virtual DbSet<Medarbejder> Medarbejders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bil>()
                .Property(e => e.Mærke)
                .IsUnicode(false);

            modelBuilder.Entity<Bil>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Bil>()
                .Property(e => e.Årgang)
                .IsUnicode(false);

            modelBuilder.Entity<Bil>()
                .Property(e => e.Farve)
                .IsUnicode(false);

            modelBuilder.Entity<Bil>()
                .HasMany(e => e.Leasings)
                .WithRequired(e => e.Bil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Fornavn)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Efternavn)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.E_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Leasing>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Medarbejder>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Medarbejder>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Medarbejder>()
                .HasMany(e => e.Leasings)
                .WithRequired(e => e.Medarbejder)
                .WillCascadeOnDelete(false);
        }
    }
}