// <copyright file="ProductImage.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Models
{
    /// <summary>
    /// Represents an image associated with a product.
    /// </summary>
    public class ProductImage
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product image.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the URL of the product image.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the associated product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the associated product. Can be null if not loaded.
        /// </summary>
        public Product? Product { get; set; }
    }
}
