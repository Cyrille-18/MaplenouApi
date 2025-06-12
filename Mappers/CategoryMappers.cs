// <copyright file="CategoryMappers.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Category;
using MaplenouApi.Dtos.Subcategory;
using MaplenouApi.Models;

namespace MaplenouApi.Mappers
{
    /// <summary>
    /// Provides extension methods for mapping Category models to DTOs.
    /// </summary>
    public static class CategoryMappers
    {
        /// <summary>
        /// Maps a <see cref="Category"/> model to a <see cref="CategoryDto"/>.
        /// </summary>
        /// <param name="categoryModel">The category model to map.</param>
        /// <returns>A <see cref="CategoryDto"/> representing the category.</returns>
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description,
                Subcategories = categoryModel.Subcategories?.Select(s => s.ToSubcategoryDto()).ToList() ?? new List<SubcategoryDto>(),
            };
        }
    }
}
