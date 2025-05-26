// <copyright file="ProductRepository.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Data;
using MaplenouApi.Dtos.Products;
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

        /// <summary>
        /// Updates an existing product asynchronously with the provided data.
        /// </summary>
        /// <param name="id">The unique identifier of the product to update.</param>
        /// <param name="productDto">The DTO containing updated product information.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the updated product if found; otherwise, null.
        /// </returns>
        public async Task<Product?> UpdateAsync(Guid id, UpdateProductRequestDto productDto)
        {
            var existingProduct = await this._context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Title = productDto.Title;
            existingProduct.Description = productDto.Description;
            existingProduct.Price = productDto.Price;
            existingProduct.Quantity = productDto.Quantity;
            existingProduct.ImageUrl = productDto.ImageUrl;

            await this._context.SaveChangesAsync();
            return existingProduct;
        }
    }
}
