// <copyright file="ProductSupplierController.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Helpers;
using MaplenouApi.Interfaces;
using MaplenouApi.Mappers;
using MaplenouApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MaplenouApi.Controllers
{
    /// <summary>
    /// Controller for managing product suppliers.
    /// </summary>
    [Route("api/product-suppliers")]
    [ApiController]
    public class ProductSupplierController : ControllerBase
    {
        private readonly IProductSupplierRepository _productSupplierRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSupplierController"/> class.
        /// </summary>
        /// <param name="productSupplierRepository">The product supplier repository.</param>
        public ProductSupplierController(IProductSupplierRepository productSupplierRepository)
        {
            this._productSupplierRepo = productSupplierRepository;
        }

        /// <summary>
        /// Retrieves all product suppliers based on the specified query parameters.
        /// </summary>
        /// <param name="queryObject">The query parameters for filtering product suppliers.</param>
        /// <returns>A list of product supplier DTOs.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductSupplierQueryObject queryObject)
        {
            var productSuppliers = await this._productSupplierRepo.GetAllAsync(queryObject);
            var productSupplierDtos = productSuppliers.Select(ps => ps.ToProductSupplierDto());
            return this.Ok(productSupplierDtos);
        }
    }
}
