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
            return this.Ok(categoryModel.ToCategoryDto());
        }
    }
}
