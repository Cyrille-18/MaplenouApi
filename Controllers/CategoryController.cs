// <copyright file="CategoryController.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Category;
using MaplenouApi.Helpers;
using MaplenouApi.Interfaces;
using MaplenouApi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MaplenouApi.Controllers
{
    /// <summary>
    /// Controller for handling category-related operations.
    /// </summary>
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="categoryRepo">The repository used for category operations.</param>
        public CategoryController(ICategoryRepository categoryRepo)
        {
            this._categoryRepo = categoryRepo;
        }

        /// <summary>
        /// Retrieves all categories based on the specified query parameters.
        /// </summary>
        /// <param name="queryObjects">The query parameters for filtering categories.</param>
        /// <returns>A list of category DTOs.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CategoryQueryObjects queryObjects)
        {
            var categories = await this._categoryRepo.GetAllAsync(queryObjects);
            var categoriesDto = categories.Select(c => c.ToCategoryDto());
            return this.Ok(categoriesDto);
        }

        /// <summary>
        /// Retrieves a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>The category DTO if found; otherwise, NotFound.</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await this._categoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.Ok(category.ToCategoryDto());
        }

        /// <summary>
        /// Creates a new category based on the provided request data.
        /// </summary>
        /// <param name="categoryRequestDto">The DTO containing the data for the new category.</param>
        /// <returns>The created category as a DTO.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryRequestDto categoryRequestDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var categoryModel = categoryRequestDto.ToCategoryFromCreateDto();
            await this._categoryRepo.CreateAsync(categoryModel);
            return this.CreatedAtAction(nameof(this.GetById), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());
        }

        /// <summary>
        /// Updates an existing category with the specified ID using the provided data.
        /// </summary>
        /// <param name="id">The unique identifier of the category to update.</param>
        /// <param name="categoryDto">The DTO containing the updated category data.</param>
        /// <returns>The updated category as a DTO if successful; otherwise, NotFound or BadRequest.</returns>
        /// <summary>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto categoryDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var updatedCategory = await this._categoryRepo.UpdateAsync(id, categoryDto);
            if (updatedCategory == null)
            {
                return this.NotFound();
            }

            return this.Ok(updatedCategory.ToCategoryDto());
        }
    }
}
