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

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="context">The database context used for accessing product data.</param>
        public ProductController(ApplicationDBContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of all products.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = this._context.Products.ToList();
            return this.Ok(products);
        }
    }
}
