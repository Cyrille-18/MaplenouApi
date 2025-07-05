// <copyright file="ApplicationRole.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MaplenouApi.Models
{
    /// <summary>
    /// Represents an application role with an optional description.
    /// </summary>
    public class ApplicationRole : IdentityRole
    {
        /// <summary>
        /// Gets or sets the description of the application role.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the collection of permissions associated with this role.
        /// </summary>
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
