// <copyright file="CategoryController.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Helpers;
using MaplenouApi.Mappers;
using MaplenouApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MaplenouApi.Controllers
{
    /// <summary>
    /// Controller for handling category-related operations.
    /// </summary>
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryController"/> class.
        /// </summary>
        /// <param name="categoryRepo">The repository used for category operations.</param>
        public CategoryController(CategoryRepository categoryRepo)
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
    }
}
