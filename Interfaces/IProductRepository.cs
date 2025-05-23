// <copyright file="IProductRepository.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Models;

namespace MaplenouApi.Interfaces
{
    /// <summary>
    /// Defines methods for accessing and managing products in the repository.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Asynchronously retrieves all products from the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of products.</returns>
        Task<List<Product>> GetAllAsync();
    }
}
