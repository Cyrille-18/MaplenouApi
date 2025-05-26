// <copyright file="CreateProductRequestDto.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Dtos.Products
{
    /// <summary>
    /// Represents the data required to create a new product.
    /// </summary>
    public class CreateProductRequestDto
    {
        /// <summary>
        /// Gets or sets product ID.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price the product.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets the Quantity of the product.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets product image.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}
