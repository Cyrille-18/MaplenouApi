// <copyright file="CreateCategoryRequestDto.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Dtos.Category
{
    /// <summary>
    /// Represents the data required to create a new category.
    /// </summary>
    public class CreateCategoryRequestDto
    {
        /// <summary>
        /// Gets or sets category name.
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the category.
        /// </summary>
        [Required]
        [StringLength(200, ErrorMessage = "Description must be at most 200 characters.")]
        public string Description { get; set; } = string.Empty;
    }
}
