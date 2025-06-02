// <copyright file="ISubcategoryRepository.cs" company="Maplenou">
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
    /// Defines methods for managing subcategories in the repository.
    /// </summary>
    public interface ISubcategoryRepository
    {
        /// <summary>
        /// Creates a new subcategory asynchronously.
        /// </summary>
        /// <param name="subcategoryModel">The subcategory model to create.</param>
        /// <returns>The created <see cref="Subcategory"/>.</returns>
        Task<Subcategory> CreateAsync(Subcategory subcategoryModel);

        /// <summary>
        /// Retrieves a subcategory by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the subcategory.</param>
        /// <returns>The <see cref="Subcategory"/> if found; otherwise, <c>null</c>.</returns>
        Task<Subcategory?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all subcategories asynchronously.
        /// </summary>
        /// <param name="queryObject">The query object containing filtering and pagination options for subcategories.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="Subcategory"/> objects.</returns>
        Task<List<Subcategory>> GetAllAsync(SubcategoryQueryObject queryObject);
    }
}
