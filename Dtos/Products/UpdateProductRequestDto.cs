// <copyright file="UpdateProductRequestDto.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Dtos.Products
{
    /// <summary>
    /// DTO for updating product information.
    /// </summary>
    public class UpdateProductRequestDto
    {
        /// <summary>
        /// Gets or sets product title.
        /// </summary>
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 150 characters.")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        [Required]
        [StringLength(1000, ErrorMessage = "Description must be at most 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price the product.
        /// </summary>
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets the Quantity of the product.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets product image.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}
