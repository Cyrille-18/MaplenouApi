// <copyright file="IProductSupplierRepository.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.ProductSupplier;
using MaplenouApi.Helpers;
using MaplenouApi.Models;

namespace MaplenouApi.Interfaces
{
    /// <summary>
    /// Defines methods for accessing and managing ProductSupplier entities in the repository.
    /// </summary>
    public interface IProductSupplierRepository
    {
        /// <summary>
        /// Retrieves all ProductSupplier entities matching the specified query object.
        /// </summary>
        /// <param name="queryObject">The query object containing filter and pagination parameters.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of ProductSupplier entities.</returns>
        Task<List<ProductSupplier>> GetAllAsync(ProductSupplierQueryObject queryObject);

        /// <summary>
        /// Creates a new ProductSupplier entity in the repository.
        /// </summary>
        /// <param name="productSupplierModel">The ProductSupplier model to create.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created ProductSupplier entity.</returns>
        Task<ProductSupplier> CreateAsync(ProductSupplier productSupplierModel);

        /// <summary>
        /// Retrieves a ProductSupplier entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the ProductSupplier entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the ProductSupplier entity if found; otherwise, null.</returns>
        Task<ProductSupplier?> GetByIdAsync(Guid id);

        /// <summary>
        /// Updates an existing ProductSupplier entity with the specified ID using the provided update DTO.
        /// </summary>
        /// <param name="id">The unique identifier of the ProductSupplier entity to update.</param>
        /// <param name="productSupplierRequestDto">The DTO containing updated values for the ProductSupplier entity.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated ProductSupplier entity if found; otherwise, null.</returns>
        Task<ProductSupplier?> UpdateAsync(Guid id, UpdateProductSupplierRequestDto productSupplierRequestDto);
    }
}
