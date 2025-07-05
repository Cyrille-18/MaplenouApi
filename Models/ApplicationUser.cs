// <copyright file="ApplicationUser.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MaplenouApi.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace MaplenouApi.Models
{
    /// <summary>
    /// Represents an application user with additional profile data.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        [Required]
        public UserType UserType { get; set; } = UserType.Customer;
    }
}
