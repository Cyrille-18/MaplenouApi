// <copyright file="ProductSupplierRepository.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Data;
using MaplenouApi.Helpers;
using MaplenouApi.Interfaces;
using MaplenouApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaplenouApi.Repository
{
    /// <summary>
    /// Repository for managing ProductSupplier entities.
    /// </summary>
    public class ProductSupplierRepository : IProductSupplierRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSupplierRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public ProductSupplierRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieves a paginated list of <see cref="ProductSupplier"/> entities based on the specified query object.
        /// </summary>
        /// <param name="queryObject">The query object containing pagination parameters.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of <see cref="ProductSupplier"/>.</returns>
        public Task<List<ProductSupplier>> GetAllAsync(ProductSupplierQueryObject queryObject)
        {
            var query = this._context.ProductSuppliers.AsQueryable();

            var skip = (queryObject.PageNumber - 1) * queryObject.PageSize;

            return query.Skip(skip)
                        .Take(queryObject.PageSize)
                        .ToListAsync();
        }

        /// <summary>
        /// Creates a new <see cref="ProductSupplier"/> entity asynchronously.
        /// </summary>
        /// <param name="productSupplierModel">The <see cref="ProductSupplier"/> model to create.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="ProductSupplier"/>.</returns>
        public async Task<ProductSupplier> CreateAsync(ProductSupplier productSupplierModel)
        {
            await this._context.ProductSuppliers.AddAsync(productSupplierModel);
            await this._context.SaveChangesAsync();
            return productSupplierModel;
        }

        /// <summary>
        /// Retrieves a <see cref="ProductSupplier"/> entity by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the <see cref="ProductSupplier"/>.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the <see cref="ProductSupplier"/> if found; otherwise, <c>null</c>.
        /// </returns>
        public async Task<ProductSupplier?> GetByIdAsync(Guid id)
        {
            return await this._context.ProductSuppliers.FirstOrDefaultAsync(ps => ps.Id == id);
        }
    }
}
