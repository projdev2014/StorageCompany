namespace StorageCompany.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StorageEntityDataModel : DbContext
    {
        public StorageEntityDataModel()
            : base("name=StorageEntityDataModel")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Movement> Movement { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<StorageType> StorageType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.postalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.streetNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.streetName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.accountRecipientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Order1)
                .WithRequired(e => e.Account1)
                .HasForeignKey(e => e.accountSenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Movement)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Movement)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Package)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Item)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Movement)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Storage>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Storage>()
                .HasMany(e => e.Movement)
                .WithRequired(e => e.Storage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Storage>()
                .HasMany(e => e.Storage1)
                .WithOptional(e => e.Storage2)
                .HasForeignKey(e => e.storageParentId);

            modelBuilder.Entity<StorageType>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<StorageType>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<StorageType>()
                .HasMany(e => e.Storage)
                .WithRequired(e => e.StorageType)
                .WillCascadeOnDelete(false);
        }
    }
}
