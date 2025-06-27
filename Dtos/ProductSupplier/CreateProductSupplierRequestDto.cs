// <copyright file="CreateProductSupplierRequestDto.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Dtos.ProductSupplier
{
    /// <summary>
    /// Represents a request to create a product-supplier relationship.
    /// </summary>
    public class CreateProductSupplierRequestDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the supplier.
        /// </summary>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the price offered by the supplier for the product.
        /// </summary>
        public float SupplierPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product supplied by the supplier.
        /// </summary>
        public int Quantity { get; set; }
    }
}
