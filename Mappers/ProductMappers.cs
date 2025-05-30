// <copyright file="ProductMappers.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Products;
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
                ImageUrls = productModel.Images.Select(img => img.ImageUrl).ToList(),
                CreatedOn = productModel.CreatedOn,
            };
        }

        /// <summary>
        /// Maps a <see cref="CreateProductRequestDto"/> to a <see cref="Product"/> model.
        /// </summary>
        /// <param name="productRequestDto">The product request DTO to map.</param>
        /// <returns>A <see cref="Product"/> instance created from the DTO.</returns>
        public static Product ToProductFromCreateDto(this CreateProductRequestDto productRequestDto)
        {
            return new Product
            {
                Title = productRequestDto.Title,
                Description = productRequestDto.Description,
                Price = productRequestDto.Price,
                Quantity = productRequestDto.Quantity,
            };
        }
    }
}
