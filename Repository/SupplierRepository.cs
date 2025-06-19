// <copyright file="SupplierRepository.cs" company="Maplenou">
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
    /// Repository class for managing supplier data.
    /// </summary>
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierRepository"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public SupplierRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a new supplier asynchronously and saves it to the database.
        /// </summary>
        /// <param name="supplierModel">The supplier model to create.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created supplier.</returns>
        public async Task<Supplier> CreateAsync(Supplier supplierModel)
        {
            await this._context.Suppliers.AddAsync(supplierModel);
            await this._context.SaveChangesAsync();
            return supplierModel;
        }

        /// <summary>
        /// Retrieves a paginated list of suppliers based on the specified query object.
        /// </summary>
        /// <param name="queryObject">The query object containing filter and pagination parameters.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of suppliers.</returns>
        public Task<List<Supplier>> GetAllAsync(SupplierQueryObject queryObject)
        {
            var suppliers = this._context.Suppliers.AsQueryable();

            if (!string.IsNullOrEmpty(queryObject.FullName))
            {
                suppliers = suppliers.Where(sp => sp.FullName.Contains(queryObject.FullName));
            }

            var skip = (queryObject.PageNumber - 1) * queryObject.PageSize;

            return suppliers.Skip(skip)
                        .Take(queryObject.PageSize)
                        .ToListAsync();
        }

        /// <summary>
        /// Retrieves a supplier by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the supplier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the supplier if found; otherwise, null.</returns>
        public async Task<Supplier?> GetByIdAsync(Guid id)
        {
            return await this._context.Suppliers.FirstOrDefaultAsync(sp => sp.SupplierId == id);
        }
    }
}
