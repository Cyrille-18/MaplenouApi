// <copyright file="Product.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Models
{
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
        /// Gets or sets the list of product images.
        /// </summary>
        public List<ProductImage> Images { get; set; } = new List<ProductImage>();

        /// <summary>
        /// Gets or sets product Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the subcategory to which the product belongs.
        /// </summary>
        public Guid SubcategoryId { get; set; }

        /// <summary>
        /// Gets or sets the subcategory to which the product belongs.
        /// </summary>
        public Subcategory? Subcategory { get; set; }

        /// <summary>
        /// Gets or sets Creation Date.
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
