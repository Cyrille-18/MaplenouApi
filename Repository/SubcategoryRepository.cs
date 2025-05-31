// <copyright file="SubcategoryRepository.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Data;
using MaplenouApi.Interfaces;
using MaplenouApi.Models;

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
    }
}
