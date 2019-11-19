namespace WebApiLeasing
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LeasingDBcontext : DbContext
    {
        public LeasingDBcontext()
            : base("name=LeasingDBcontext")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Bil> Bil { get; set; }
        public virtual DbSet<Kunde> Kunde { get; set; }
        public virtual DbSet<Leasing> Leasing { get; set; }
        public virtual DbSet<Medarbejder> Medarbejder { get; set; }
        public virtual DbSet<Table> Table { get; set; }

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
                .HasMany(e => e.Leasing)
                .WithRequired(e => e.Bil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.E_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .HasMany(e => e.Leasing)
                .WithRequired(e => e.Kunde)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Leasing>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Medarbejder>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Medarbejder>()
                .Property(e => e.E_mail)
                .IsUnicode(false);

            modelBuilder.Entity<Medarbejder>()
                .HasMany(e => e.Leasing)
                .WithRequired(e => e.Medarbejder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Mærke)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Årgang)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Farve)
                .IsUnicode(false);
        }
    }
}
