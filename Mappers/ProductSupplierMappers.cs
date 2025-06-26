// <copyright file="ProductSupplierMappers.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.ProductSupplier;
using MaplenouApi.Models;

namespace MaplenouApi.Mappers
{
    /// <summary>
    /// Provides extension methods for mapping ProductSupplier models to DTOs.
    /// </summary>
    public static class ProductSupplierMappers
    {
        /// <summary>
        /// Maps a <see cref="ProductSupplier"/> model to a <see cref="ProductSupplierDto"/>.
        /// </summary>
        /// <param name="productSupplierModel">The product supplier model to map.</param>
        /// <returns>A <see cref="ProductSupplierDto"/> representing the mapped model.</returns>
        public static ProductSupplierDto ToProductSupplierDto(this ProductSupplier productSupplierModel)
        {
            return new ProductSupplierDto
            {
                ProductId = productSupplierModel.ProductId,
                SupplierId = productSupplierModel.SupplierId,
                SupplierPrice = productSupplierModel.SupplierPrice,
                Quantity = productSupplierModel.Quantity,
                CreatedOn = productSupplierModel.CreatedOn ?? DateTime.UtcNow,
            };
        }
    }
}
