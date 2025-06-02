// <copyright file="SubcategoryRepository.cs" company="Maplenou">
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
    /// Provides methods for accessing and managing subcategory data in the repository.
    /// </summary>
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubcategoryRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public SubcategoryRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Asynchronously creates a new subcategory in the database.
        /// </summary>
        /// <param name="subcategoryModel">The subcategory model to add.</param>
        /// <returns>The created <see cref="Subcategory"/> entity.</returns>
        public async Task<Subcategory> CreateAsync(Subcategory subcategoryModel)
        {
            await this._context.Subcategories.AddAsync(subcategoryModel);
            await this._context.SaveChangesAsync();
            return subcategoryModel;
        }

        /// <summary>
        /// Asynchronously retrieves a subcategory by its unique identifier, including its related products.
        /// </summary>
        /// <param name="id">The unique identifier of the subcategory.</param>
        /// <returns>The <see cref="Subcategory"/> entity if found; otherwise, <c>null</c>.</returns>
        public async Task<Subcategory?> GetByIdAsync(Guid id)
        {
            return await this._context.Subcategories.Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Asynchronously retrieves a paginated list of subcategories based on the specified query parameters.
        /// </summary>
        /// <param name="queryObject">The query object containing filtering, paging, and inclusion options.</param>
        /// <returns>A task representing the asynchronous operation, with a list of <see cref="Subcategory"/> entities as the result.</returns>
        public Task<List<Subcategory>> GetAllAsync(SubcategoryQueryObject queryObject)
        {
            var query = this._context.Subcategories.AsQueryable();

            if (!string.IsNullOrEmpty(queryObject.Name))
            {
                query = query.Where(s => s.Name.Contains(queryObject.Name));
            }

            if (queryObject.IncludeProducts)
            {
                query = query.Include(s => s.Products);
            }

            var skip = (queryObject.PageNumber - 1) * queryObject.PageSize;

            return query.Skip(skip)
                        .Take(queryObject.PageSize)
                        .ToListAsync();
        }
    }
}
