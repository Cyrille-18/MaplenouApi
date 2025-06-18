// <copyright file="ISupplierRepository.cs" company="Maplenou">
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
    }
}
