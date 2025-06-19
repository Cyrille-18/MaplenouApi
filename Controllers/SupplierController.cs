// <copyright file="SupplierController.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.Supplier;
using MaplenouApi.Helpers;
using MaplenouApi.Interfaces;
using MaplenouApi.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace MaplenouApi.Controllers
{
    /// <summary>
    /// Controller for managing suppliers.
    /// </summary>
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierController"/> class.
        /// </summary>
        /// <param name="supplierRepo">The supplier repository instance.</param>
        public SupplierController(ISupplierRepository supplierRepo)
        {
            this._supplierRepo = supplierRepo;
        }

        /// <summary>
        /// Retrieves all suppliers based on the specified query parameters.
        /// </summary>
        /// <param name="queryObject">The query parameters for filtering suppliers.</param>
        /// <returns>A list of supplier DTOs.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SupplierQueryObject queryObject)
        {
            var suppliers = await this._supplierRepo.GetAllAsync(queryObject);
            var suppliersDto = suppliers.Select(sp => sp.ToSupplierDto());
            return this.Ok(suppliersDto);
        }

        /// <summary>
        /// Creates a new supplier using the provided supplier data.
        /// </summary>
        /// <param name="supplierDto">The supplier data transfer object containing the supplier information.</param>
        /// <returns>The created supplier DTO.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierRequestDto supplierDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var supplierModel = supplierDto.ToSupplierFromCreateDto();
            await this._supplierRepo.CreateAsync(supplierModel);
            var createdSupplierDto = supplierModel.ToSupplierDto();
            return this.Ok(createdSupplierDto);
        }
    }
}
