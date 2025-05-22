// <copyright file="ProductMappers.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos;
using MaplenouApi.Models;

namespace MaplenouApi.Mappers
{
    /// <summary>
    /// Provides mapping methods for converting between Product models and ProductDto objects.
    /// </summary>
    public static class ProductMappers
    {
        /// <summary>
        /// Maps a <see cref="Product"/> model to a <see cref="ProductDto"/>.
        /// </summary>
        /// <param name="productModel">The product model to map.</param>
        /// <returns>A <see cref="ProductDto"/> representing the product.</returns>
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Title = productModel.Title,
                Description = productModel.Description,
                Price = productModel.Price,
                Quantity = productModel.Quantity,
                ImageUrl = productModel.ImageUrl,
                CreatedOn = productModel.CreatedOn,
            };
        }
    }
}
