// <copyright file="SubcategoryController.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Subcategory;
using MaplenouApi.Helpers;
using MaplenouApi.Interfaces;
using MaplenouApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace MaplenouApi.Controllers
{
    /// <summary>
    /// Controller for handling subcategory-related API requests.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for managing subcategories.
    /// </remarks>
    [Route("Api/Subcategory")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryRepository _subcategoryRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubcategoryController"/> class.
        /// </summary>
        /// <param name="subcategoryRepo">The repository for subcategory operations.</param>
        public SubcategoryController(ISubcategoryRepository subcategoryRepo)
        {
            this._subcategoryRepo = subcategoryRepo;
        }

        /// <summary>
        /// Creates a new subcategory.
        /// </summary>
        /// <param name="subcategoryDto">The DTO containing subcategory creation data.</param>
        /// <returns>An IActionResult indicating the result of the creation operation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSubcategoryRequestDto subcategoryDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var subcategoryModel = subcategoryDto.ToSubcategoryFromCreateDto();
            await this._subcategoryRepo.CreateAsync(subcategoryModel);
            return this.CreatedAtAction(nameof(this.GetById), new { id = subcategoryModel.Id }, subcategoryModel);
        }

        /// <summary>
        /// Retrieves a subcategory by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the subcategory.</param>
        /// <returns>An IActionResult containing the subcategory data if found; otherwise, NotFound.</returns>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var subcategory = await this._subcategoryRepo.GetByIdAsync(id);
            if (subcategory == null)
            {
                return this.NotFound();
            }

            return this.Ok(subcategory.ToSubcategoryDto());
        }

        /// <summary>
        /// Retrieves all subcategories based on the specified query parameters.
        /// </summary>
        /// <param name="queryObject">The query parameters for filtering and pagination.</param>
        /// <returns>An IActionResult containing a list of subcategory DTOs.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SubcategoryQueryObject queryObject)
        {
            var subcategories = await this._subcategoryRepo.GetAllAsync(queryObject);
            var subcategoryDtos = subcategories.Select(s => s.ToSubcategoryDto());
            return this.Ok(subcategoryDtos);
        }
    }
}
