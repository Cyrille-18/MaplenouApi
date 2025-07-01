// <copyright file="ProductSupplierController.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Dtos.ProductSupplier;
using MaplenouApi.Helpers;
using MaplenouApi.Interfaces;
using MaplenouApi.Mappers;
using MaplenouApi.Models;
using MaplenouApi.Repository;
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
        private readonly ISupplierRepository _supplierRepo;
        private readonly IProductRepository _productRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSupplierController"/> class.
        /// </summary>
        /// <param name="productSupplierRepository">The product supplier repository.</param>
        /// <param name="supplierRepository">The supplier repository.</param>
        /// <param name="productRepository">The product repository.</param>
        public ProductSupplierController(IProductSupplierRepository productSupplierRepository, ISupplierRepository supplierRepository, IProductRepository productRepository)
        {
            this._productSupplierRepo = productSupplierRepository;
            this._supplierRepo = supplierRepository;
            this._productRepo = productRepository;
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

        /// <summary>
        /// Retrieves a product supplier by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product supplier.</param>
        /// <returns>The product supplier DTO if found; otherwise, NotFound.</returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var productSupplier = await this._productSupplierRepo.GetByIdAsync(id);
            if (productSupplier == null)
            {
                return this.NotFound();
            }

            return this.Ok(productSupplier.ToProductSupplierDto());
        }

        /// <summary>
        /// Creates a new product supplier.
        /// </summary>
        /// <param name="productSupplierRequestDto">The product supplier request DTO.</param>
        /// <returns>The created product supplier DTO.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductSupplierRequestDto productSupplierRequestDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (await this._productRepo.ExistsById(productSupplierRequestDto.ProductId) == false)
            {
                return this.NotFound($"Product does not exist.");
            }

            if (await this._supplierRepo.ExistsById(productSupplierRequestDto.SupplierId) == false)
            {
                return this.NotFound($"Supplier does not exist.");
            }

            var productSupplier = productSupplierRequestDto.ToProductSupplierFromCreateDto();
            var createdProductSupplier = await this._productSupplierRepo.CreateAsync(productSupplier);
            return this.CreatedAtAction(nameof(this.GetById), new { id = createdProductSupplier.Id }, createdProductSupplier.ToProductSupplierDto());
        }

        /// <summary>
        /// Updates an existing product supplier.
        /// </summary>
        /// <param name="id">The unique identifier of the product supplier to update.</param>
        /// <param name="productSupplierDto">The updated product supplier data.</param>
        /// <returns>The updated product supplier DTO if successful; otherwise, NotFound or BadRequest.</returns>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductSupplierRequestDto productSupplierDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (await this._productRepo.ExistsById(productSupplierDto.ProductId) == false)
            {
                return this.NotFound($"Product does not exist.");
            }

            if (await this._supplierRepo.ExistsById(productSupplierDto.SupplierId) == false)
            {
                return this.NotFound($"Supplier does not exist.");
            }

            var productSupplierModel = await this._productSupplierRepo.UpdateAsync(id, productSupplierDto);
            if (productSupplierModel == null)
            {
                return this.NotFound();
            }

            return this.Ok(productSupplierModel.ToProductSupplierDto());
        }
    }
}
