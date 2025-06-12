// <copyright file="CategoryDto.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Subcategory;

namespace MaplenouApi.Dtos.Category
{
    /// <summary>
    /// Data Transfer Object representing a category.
    /// </summary>
    public class CategoryDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the category.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of subcategories associated with the category.
        /// </summary>
        public List<SubcategoryDto> Subcategories { get; set; } = new List<SubcategoryDto>();
    }
}
