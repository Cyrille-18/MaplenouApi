// <copyright file="CreateSubcategoryRequestDto.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Dtos.Subcategory
{
    /// <summary>
    /// Represents the data required to create a subcategory.
    /// </summary>
    public class CreateSubcategoryRequestDto
    {
        /// <summary>
        /// Gets or sets subcategory Name.
        /// </summary>
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets subcategory Description.
        /// </summary>
        [Required]
        [MaxLength(300, ErrorMessage = "Description cannot exceed 300 characters.")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the category to which this subcategory belongs.
        /// </summary>
        [Required(ErrorMessage = "Category is required")]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the subcategory is active.
        /// </summary>
        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
