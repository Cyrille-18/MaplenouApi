// <copyright file="ProductRepository.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Data;
using MaplenouApi.Interfaces;
using MaplenouApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaplenouApi.Repository
{
    /// <summary>
    /// Repository class for managing product data access.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.(dependency injection).
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public ProductRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieves all products asynchronously from the database.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of products.</returns>
        public Task<List<Product>> GetAllAsync()
        {
            return this._context.Products.ToListAsync();
        }

        /// <summary>
        /// Retrieves a product by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the product if found; otherwise, null.
        /// </returns>
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await this._context.Products.FindAsync(id);
        }

        /// <summary>
        /// Creates a new product asynchronously and saves it to the database.
        /// </summary>
        /// <param name="productModel">The product model to create.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the created product.
        /// </returns>
        public async Task<Product> CreateAsync(Product productModel)
        {
            await this._context.Products.AddAsync(productModel);
            await this._context.SaveChangesAsync();
            return productModel;
        }
    }
}
