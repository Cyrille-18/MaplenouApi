// <copyright file="ApplicationDBContext.cs" company="Maplenou">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MaplenouApi.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MaplenouApi.Models;
    using Microsoft.EntityFrameworkCore;

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
    }
}