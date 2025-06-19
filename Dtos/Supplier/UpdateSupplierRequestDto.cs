// <copyright file="UpdateSupplierRequestDto.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Dtos.Supplier
{
    /// <summary>
    /// DTO for updating supplier information.
    /// </summary>
    public class UpdateSupplierRequestDto
    {
        /// <summary>
        /// Gets or sets the fullname of the supplier.
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phoneNumber of the supplier.
        /// </summary>
        [Required]
        [MaxLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
