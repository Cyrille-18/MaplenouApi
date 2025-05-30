// <copyright file="FileService.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Interfaces;

namespace MaplenouApi.Services
{
    /// <summary>
    /// Provides file-related services such as saving product images.
    /// </summary>
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileService"/> class.
        /// </summary>
        /// <param name="env">The web host environment used for accessing environment-specific information.</param>
        public FileService(IWebHostEnvironment env)
        {
            this._env = env;
        }

        /// <summary>
        /// Saves product images asynchronously.
        /// </summary>
        /// <param name="images">The collection of images to save.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of saved image paths.</returns>
        public async Task<List<string>> SaveProductImagesAsync(ICollection<IFormFile> images)
        {
            var savedPaths = new List<string>();
            var imageDirectory = Path.Combine(this._env.WebRootPath, "Images", "Products");

            Directory.CreateDirectory(imageDirectory);

            foreach (var image in images)
            {
                var uniqueName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                var path = Path.Combine(imageDirectory, uniqueName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                savedPaths.Add($"/Images/Products/{uniqueName}");
            }

            return savedPaths;
        }
    }
}
