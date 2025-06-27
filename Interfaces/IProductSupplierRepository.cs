// <copyright file="IProductSupplierRepository.cs" company="Maplenou">
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
    }
}
