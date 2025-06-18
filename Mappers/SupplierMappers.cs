// <copyright file="SupplierMappers.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Supplier;
using MaplenouApi.Models;

namespace MaplenouApi.Mappers
{
    /// <summary>
    /// Provides mapping methods for converting between Supplier models and DTOs.
    /// </summary>
    public static class SupplierMappers
    {
        /// <summary>
        /// Converts a <see cref="Supplier"/> model to a <see cref="SupplierDto"/>.
        /// </summary>
        /// <param name="supplierModel">The supplier model to convert.</param>
        /// <returns>A <see cref="SupplierDto"/> representation of the supplier.</returns>
        public static SupplierDto ToSupplierDto(this Supplier supplierModel)
        {
            return new SupplierDto
            {
                SupplierId = supplierModel.SupplierId,
                FullName = supplierModel.FullName,
                PhoneNumber = supplierModel.PhoneNumber,
                CreatedOn = supplierModel.CreatedOn,
            };
        }
    }
}
