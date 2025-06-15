// <copyright file="ICategoryRepository.cs" company="Maplenou">
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
    public interface ICategoryRepository
    {
        /// <summary>
        /// Asynchronously retrieves a list of categories based on the specified query parameters.
        /// </summary>
        /// <param name="queryObject">The query object containing filtering and paging options.</param>
        /// <returns>A task representing the asynchronous operation, with a list of <see cref="Category"/> entities as the result.</returns>
        Task<List<Category>> GetAllAsync(CategoryQueryObjects queryObject);

        /// <summary>
        /// Asynchronously creates a new category.
        /// </summary>
        /// <param name="categoryModel">The category model to create.</param>
        /// <returns>A task representing the asynchronous operation, with the created <see cref="Category"/> as the result.</returns>
        Task<Category> CreateAsync(Category categoryModel);

        /// <summary>
        /// Asynchronously retrieves a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>A task representing the asynchronous operation, with the <see cref="Category"/> entity as the result, or null if not found.</returns>
        Task<Category?> GetByIdAsync(Guid id);
    }
}
