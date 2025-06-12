// <copyright file="CategoryQueryObjects.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Helpers
{
    /// <summary>
    /// Represents query parameters for filtering and paginating category results.
    /// </summary>
    public class CategoryQueryObjects
    {
        /// <summary>
        /// Gets or sets the name to filter categories by.
        /// </summary>
        public string? Name { get; set; } = null;

        /// <summary>
        /// Gets or sets the current page number for paginated categories results.
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets the number of categoires to return per page.
        /// </summary>
        public int PageSize { get; set; } = 20;

        /// <summary>
        /// Gets or sets a value indicating whether to include subcategories in the results.
        /// </summary>
        public bool IncludeSubcategories { get; set; } = false;
    }
}
