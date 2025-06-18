// <copyright file="Supplier.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Models
{
    /// <summary>
    /// Represents a supplier entity.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Supplier.
        /// </summary>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the fullname of the supplier.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phoneNumber of the supplier.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the supplier was created.
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the list of product-supplier relationships for this supplier.
        /// </summary>
        public List<ProductSupplier> ProductSuppliers { get; set; } = new();
    }
}
