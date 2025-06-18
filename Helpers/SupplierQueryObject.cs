// <copyright file="SupplierQueryObject.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Helpers
{
    /// <summary>
    /// Represents the query parameters for filtering and paginating supplier results.
    /// </summary>
    public class SupplierQueryObject
    {
        /// <summary>
        /// Gets or sets the fullName to filter by.
        /// </summary>
        public string? FullName { get; set; } = null;

        /// <summary>
        /// Gets or sets the current page number for paginated suppliers results.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the number of suppliers to return per page.
        /// </summary>
        public int PageSize { get; set; } = 20;
    }
}
