// <copyright file="SupplierController.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
