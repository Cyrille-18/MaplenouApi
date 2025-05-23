// <copyright file="ProductController.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using MaplenouApi.Data;
using MaplenouApi.Dtos.Products;
using MaplenouApi.Interfaces;
using MaplenouApi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MaplenouApi.Controllers
{
    /// <summary>
    /// Controller for handling product-related API requests.
    /// </summary>
    [Route("Api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductRepository _productRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="context">The database context used for accessing product data.</param>
        /// <param name="productRepo">The product repository used for product-related operations.</param>
        public ProductController(ApplicationDBContext context, IProductRepository productRepo)
        {
            this._context = context;
            this._productRepo = productRepo;
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of all products.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await this._productRepo.GetAllAsync();
            var productDtos = products.Select(p => p.ToProductDto());
            return this.Ok(productDtos);
        }

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The product with the specified ID, or NotFound if it does not exist.</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var product = this._context.Products.Find(id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.Ok(product.ToProductDto());
        }

        /// <summary>
        /// Creates a new product in the database.
        /// </summary>
        /// <param name="productRequestDto">The product data to create.</param>
        /// <returns>The created product with its unique identifier.</returns>
        [HttpPost]
        public IActionResult Create([FromBody] CreateProductRequestDto productRequestDto)
        {
            var productModel = productRequestDto.ToProductFromCreateDto();
            this._context.Products.Add(productModel);
            this._context.SaveChanges();
            return this.CreatedAtAction(nameof(this.GetById), new { id = productModel.Id }, productModel.ToProductDto());
        }

        /// <summary>
        /// Updates an existing product with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the product to update.</param>
        /// <param name="updateDto">The updated product data.</param>
        /// <returns>The updated product, or NotFound if it does not exist.</returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateProductRequestDto updateDto)
        {
            var productModel = this._context.Products.FirstOrDefault(p => p.Id == id);
            if (productModel == null)
            {
                return this.NotFound();
            }

            productModel.Title = updateDto.Title;
            productModel.Description = updateDto.Description;
            productModel.Price = updateDto.Price;
            productModel.Quantity = updateDto.Quantity;
            productModel.ImageUrl = updateDto.ImageUrl;

            this._context.SaveChanges();

            return this.Ok(productModel.ToProductDto());
        }

        /// <summary>
        /// Deletes a product with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns>NoContent if the product was deleted, or NotFound if it does not exist.</returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var productModel = this._context.Products.FirstOrDefault(p => p.Id == id);
            if (productModel == null)
            {
                return this.NotFound();
            }

            this._context.Products.Remove(productModel);
            this._context.SaveChanges();

            return this.NoContent();
        }
    }
}
