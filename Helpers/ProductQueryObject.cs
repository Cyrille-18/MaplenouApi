// <copyright file="ProductQueryObject.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Helpers
{
    /// <summary>
    /// Represents query parameters for filtering products.
    /// </summary>
    public class ProductQueryObject
    {
        /// <summary>
        /// Gets or sets the product title to filter by.
        /// </summary>
        public string? Title { get; set; } = null;

        /// <summary>
        /// Gets or sets the field by which to sort the products.
        /// </summary>
        public string? Sortby { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether the sort order is descending.
        /// </summary>
        public bool IsDescending { get; set; } = false;

        /// <summary>
        /// Gets or sets the current page number for paginated product results.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the number of products to return per page.
        /// </summary>
        public int PageSize { get; set; } = 20;
    }
}
