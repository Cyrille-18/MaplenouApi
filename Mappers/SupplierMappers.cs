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

        /// <summary>
        /// Converts a <see cref="CreateSupplierRequestDto"/> to a <see cref="Supplier"/> model.
        /// </summary>
        /// <param name="supplierRequestDto">The DTO containing supplier creation data.</param>
        /// <returns>A new <see cref="Supplier"/> instance populated from the DTO.</returns>
        public static Supplier ToSupplierFromCreateDto(this CreateSupplierRequestDto supplierRequestDto)
        {
            return new Supplier
            {
                FullName = supplierRequestDto.FullName,
                PhoneNumber = supplierRequestDto.PhoneNumber,
                ProductSuppliers = new List<ProductSupplier>(), // Initialize to avoid null reference
            };
        }
    }
}
