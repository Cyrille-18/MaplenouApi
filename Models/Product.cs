// <copyright file="Product.cs" company="Maplenou">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MaplenouApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a product in the system.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets product ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets product Title.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets product Description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets product Price.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets product image.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets product Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets Creation Date.
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}