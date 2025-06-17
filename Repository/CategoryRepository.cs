// <copyright file="CategoryRepository.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Data;
using MaplenouApi.Dtos.Category;
using MaplenouApi.Helpers;
using MaplenouApi.Interfaces;
using MaplenouApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaplenouApi.Repository
{
    /// <summary>
    /// Repository class for handling Category related data operations.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
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

        /// <summary>
        /// Creates a new category asynchronously and saves it to the database.
        /// </summary>
        /// <param name="categoryModel">The category model to create.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created category.</returns>
        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await this._context.Categories.AddAsync(categoryModel);
            await this._context.SaveChangesAsync();
            return categoryModel;
        }

        /// <summary>
        /// Retrieves a category by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the category if found; otherwise, null.</returns>
        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await this._context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Updates an existing category asynchronously with the provided data.
        /// </summary>
        /// <param name="id">The unique identifier of the category to update.</param>
        /// <param name="categoryDto">The data transfer object containing updated category information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated category if found; otherwise, null.</returns>
        public async Task<Category?> UpdateAsync(Guid id, UpdateCategoryRequestDto categoryDto)
        {
            var existingCategory = this._context.Categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Name = categoryDto.Name;
            existingCategory.Description = categoryDto.Description;

            await this._context.SaveChangesAsync();

            return existingCategory;
        }

        /// <summary>
        /// Deletes a category by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deleted category if found; otherwise, null.</returns>
        public async Task<Category?> DeleteAsync(Guid id)
        {
            var categoryModel = this._context.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryModel == null)
            {
                return null;
            }

            this._context.Categories.Remove(categoryModel);
            await this._context.SaveChangesAsync();

            return categoryModel;
        }
    }
}
