// <copyright file="SubcategoryDto.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Models;

namespace MaplenouApi.Dtos.Subcategory
{
    /// <summary>
    /// Data Transfer Object for Subcategory.
    /// </summary>
    public class SubcategoryDto
    {
        /// <summary>
        /// Gets or sets subcategory ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets subcategory Name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets subcategory Description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the subcategory is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the list of products associated with this subcategory.
        /// </summary>
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
