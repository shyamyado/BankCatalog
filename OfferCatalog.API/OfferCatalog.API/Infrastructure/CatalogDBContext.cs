﻿using Microsoft.EntityFrameworkCore;
using OfferCatalog.API.Infrastructure.EntityConfiguration;
using OfferCatalog.API.Models;
using OfferCatalog.API.ViewModels;

namespace OfferCatalog.API.Infrastructure
{
    public class CatalogDBContext : DbContext
    {
        private const string ConnectionString = "Server=SHYAMASUS\\SQLEXPRESS;Initial Catalog=OfferCatalog;Integrated Security=true;TrustServerCertificate=True;";

        public CatalogDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ItemViewModel> Items { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<RewardPoints> RewardPoints { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BenefitEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentEnityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PriceEntityTypeConfiguraiotn());
            modelBuilder.ApplyConfiguration(new RewardPointsEnitityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
