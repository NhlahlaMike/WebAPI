using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                    new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                    new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
                );
/*
            builder.Entity<Product>()
                        .HasOne(p => p.ProductSubCategory)
                        .WithMany(b => b.Product)
                        .HasForeignKey(p => p.ProductSubCategoryID)
                        .HasConstraintName("ForeignKey_Product_ProductSubCategory");
            builder.Entity<ProductModel>()
                        .HasOne(p => p.ProductSubCategoryModel)
                        .WithMany(b => b.ProductModel)
                        .HasForeignKey(p => p.ProductSubCategoryID)
                        .HasConstraintName("ForeignKey_ProductModel_ProductSubCategoryModel");
            builder.Entity<Product>()
                        .HasOne(p => p.ProductSubCategory)
                        .WithMany(b => b.Product)
                        .HasForeignKey(p => p.ProductSubCategoryID)
                        .HasConstraintName("ForeignKey_Product_ProductSubCategory");*/
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }

    }
}
