// <copyright file="IProductRepository.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Products;
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

        /// <summary>
        /// Asynchronously retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the product if found; otherwise, null.</returns>
        Task<Product?> GetByIdAsync(Guid id);

        /// <summary>
        /// Asynchronously creates a new product in the repository.
        /// </summary>
        /// <param name="productModel">The product model to create.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created product.</returns>
        Task<Product> CreateAsync(Product productModel);

        /// <summary>
        /// Asynchronously updates an existing product in the repository.
        /// </summary>
        /// <param name="id">The unique identifier of the product to update.</param>
        /// <param name="productDto">The DTO containing updated product information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated product if found; otherwise, null.</returns>
        Task<Product?> UpdateAsync(Guid id, UpdateProductRequestDto productDto);

        /// <summary>
        /// Asynchronously deletes a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deleted product if found; otherwise, null.</returns>
        Task<Product?> DeleteAsync(Guid id);
    }
}
