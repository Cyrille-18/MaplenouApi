// <copyright file="ISupplierRepository.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Supplier;
using MaplenouApi.Helpers;
using MaplenouApi.Models;

namespace MaplenouApi.Interfaces
{
    /// <summary>
    /// Defines methods for supplier repository operations.
    /// </summary>
    public interface ISupplierRepository
    {
        /// <summary>
        /// Gets all suppliers asynchronously based on the specified query object.
        /// </summary>
        /// <param name="queryObject">The query object containing filter parameters.</param>
        /// <returns>A list of suppliers matching the query.</returns>
        public Task<List<Supplier>> GetAllAsync(SupplierQueryObject queryObject);

        /// <summary>
        /// Creates a new supplier asynchronously.
        /// </summary>
        /// <param name="supplierModel">The supplier model to create.</param>
        /// <returns>The created supplier.</returns>
        Task<Supplier> CreateAsync(Supplier supplierModel);

        /// <summary>
        /// Gets a supplier by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the supplier.</param>
        /// <returns>The supplier with the specified ID, or null if not found.</returns>
        Task<Supplier?> GetByIdAsync(Guid id);

        /// <summary>
        /// Updates an existing supplier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the supplier to update.</param>
        /// <param name="supplierDto">The DTO containing updated supplier information.</param>
        /// <returns>The updated supplier, or null if not found.</returns>
        Task<Supplier?> UpdateAsync(Guid id, UpdateSupplierRequestDto supplierDto);

        /// <summary>
        /// Deletes a supplier by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the supplier to delete.</param>
        /// <returns>The deleted supplier, or null if not found.</returns>
        Task<Supplier?> DeleteAsync(Guid id);

        /// <summary>
        /// Checks if a supplier exists by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the supplier.</param>
        /// <returns>True if the supplier exists; otherwise, false.</returns>
        Task<bool> ExistsById(Guid id);
    }
}
