// <copyright file="ApplicationDBContext.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaplenouApi.Data
{
    /// <summary>
    /// Represents the application database context.
    /// </summary>
    public class ApplicationDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDBContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by the DBcontext.</param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Products table.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the ProductImages table.
        /// </summary>
        public DbSet<ProductImage> ProductImages { get; set; }

        /// <summary>
        /// Gets or sets the Subcategories table.
        /// </summary>
        public DbSet<Subcategory> Subcategories { get; set; }

        /// <summary>
        /// Configures the relationships and schema.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One Product has many ProductImages
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // One Subcategory has many Products
            modelBuilder.Entity<Subcategory>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Subcategory)
                .HasForeignKey(p => p.SubcategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
