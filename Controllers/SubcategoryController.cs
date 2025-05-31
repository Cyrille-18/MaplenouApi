// <copyright file="SubcategoryController.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Subcategory;
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
            return this.CreatedAtAction(nameof(GetById), new { id = subcategoryModel.Id }, subcategoryModel);
        }
    }
}
