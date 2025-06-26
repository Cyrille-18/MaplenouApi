// <copyright file="ProductSupplierQueryObject.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Helpers
{
    /// <summary>
    /// Represents query parameters for paginating ProductSupplier results.
    /// </summary>
    public class ProductSupplierQueryObject
    {
        /// <summary>
        /// Gets or sets the current page number for paginated productSupplier results.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the number of productSupplier to return per page.
        /// </summary>
        public int PageSize { get; set; } = 20;
    }
}
