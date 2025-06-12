// <copyright file="ICategory.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Helpers;
using MaplenouApi.Models;

namespace MaplenouApi.Interfaces
{
    /// <summary>
    /// Defines methods for accessing and managing category data.
    /// </summary>
    public interface ICategory
    {
        /// <summary>
        /// Asynchronously retrieves a list of categories based on the specified query parameters.
        /// </summary>
        /// <param name="queryObject">The query object containing filtering and paging options.</param>
        /// <returns>A task representing the asynchronous operation, with a list of <see cref="Category"/> entities as the result.</returns>
        Task<List<Category>> GetAllAsync(CategoryQueryObjects queryObject);
    }
}
