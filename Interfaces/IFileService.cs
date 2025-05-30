// <copyright file="IFileService.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Interfaces
{
    /// <summary>
    /// Provides methods for saving and managing files, such as product images.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Saves the provided product images asynchronously and returns the list of saved file paths.
        /// </summary>
        /// <param name="images">The collection of images to save.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of saved image file paths.</returns>
        Task<List<string>> SaveProductImagesAsync(ICollection<IFormFile> images);
    }
}
