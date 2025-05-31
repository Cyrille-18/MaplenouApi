// <copyright file="SubcategoryMappers.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Subcategory;
using MaplenouApi.Models;

namespace MaplenouApi.Mappers
{
    /// <summary>
    /// Provides mapping methods for subcategory-related operations.
    /// </summary>
    public static class SubcategoryMappers
    {
        /// <summary>
        /// Maps a <see cref="CreateSubcategoryRequestDto"/> to a <see cref="Subcategory"/> model.
        /// </summary>
        /// <param name="subcategoryRequestDto">The DTO containing subcategory creation data.</param>
        /// <returns>A new <see cref="Subcategory"/> instance populated from the DTO.</returns>
        public static Subcategory ToSubcategoryFromCreateDto(this CreateSubcategoryRequestDto subcategoryRequestDto)
        {
            return new Subcategory
            {
                Name = subcategoryRequestDto.Name,
                Description = subcategoryRequestDto.Description,
                IsActive = subcategoryRequestDto.IsActive,
            };
        }

        /// <summary>
        /// Maps a <see cref="Subcategory"/> model to a <see cref="Subcategory"/> DTO.
        /// </summary>
        /// <param name="subcategoryModel">The subcategory model to map from.</param>
        /// <returns>A new <see cref="Subcategory"/> instance populated from the model.</returns>
        public static Subcategory ToSubcategoryDto(this Subcategory subcategoryModel)
        {
            return new Subcategory
            {
                Id = subcategoryModel.Id,
                Name = subcategoryModel.Name,
                Description = subcategoryModel.Description,
                IsActive = subcategoryModel.IsActive,
                Products = subcategoryModel.Products ?? new List<Product>(),
            };
        }
    }
}
