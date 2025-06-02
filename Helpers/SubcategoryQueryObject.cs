// <copyright file="SubcategoryQueryObject.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Helpers
{
    /// <summary>
    /// Represents a query object for subcategories.
    /// </summary>
    public class SubcategoryQueryObject
    {
        /// <summary>
        /// Gets or sets the subcategory Name to filter by.
        /// </summary>
        public string? Name { get; set; } = null;

        /// <summary>
        /// Gets or sets the current page number for paginated subcategories results.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the number of subcategories to return per page.
        /// </summary>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// Gets or sets a value indicating whether to include products in the subcategory results.
        /// </summary>
        public bool IncludeProducts { get; set; } = false;
    }
}
