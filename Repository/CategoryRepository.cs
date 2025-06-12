// <copyright file="CategoryRepository.cs" company="Maplenou">
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
    /// Repository class for handling Category related data operations.
    /// </summary>
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDBContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public CategoryRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieves a list of categories based on the specified query parameters.
        /// </summary>
        /// <param name="queryObject">The query parameters for filtering, paging, and including subcategories.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of categories.</returns>
        public Task<List<Category>> GetAllAsync(CategoryQueryObjects queryObject)
        {
            var categories = this._context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryObject.Name))
            {
                categories = categories.Where(c => c.Name.Contains(queryObject.Name));
            }

            if (queryObject.IncludeSubcategories)
            {
                categories = categories.Include(c => c.Subcategories);
            }

            var skip = (queryObject.PageNumber - 1) * queryObject.PageSize;

            return categories
                .Skip(skip)
                .Take(queryObject.PageSize)
                .ToListAsync();
        }
    }
}
