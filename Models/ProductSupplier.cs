// <copyright file="ProductSupplier.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Models
{
    /// <summary>
    /// Represents the association between a product and a supplier, including pricing and delivery details.
    /// </summary>
    public class ProductSupplier
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product associated with the supplier.
        /// </summary>
        public Product Product { get; set; } = default!;

        /// <summary>
        /// Gets or sets the unique identifier of the supplier.
        /// </summary>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the supplier associated with the product.
        /// </summary>
        public Supplier Supplier { get; set; } = default!;

        // Champs optionnels

        /// <summary>
        /// Gets or sets the price offered by the supplier for the product.
        /// </summary>
        public float SupplierPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product supplied by the supplier.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the product-supplier association was created.
        /// </summary>
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
