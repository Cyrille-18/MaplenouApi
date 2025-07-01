// <copyright file="UpdateProductSupplierRequestDto.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Dtos.ProductSupplier
{
    /// <summary>
    /// DTO for updating the association between a product and a supplier.
    /// </summary>
    public class UpdateProductSupplierRequestDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        [Required(ErrorMessage = "ProductId is required.")]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the supplier.
        /// </summary>
        [Required(ErrorMessage = "SupplierId is required.")]
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the price offered by the supplier for the product.
        /// </summary>
        [Required(ErrorMessage = "SupplierPrice is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "SupplierPrice must be greater than 0")]
        public float SupplierPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product supplied by the supplier.
        /// </summary>
        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
    }
}
