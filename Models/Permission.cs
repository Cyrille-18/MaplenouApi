// <copyright file="Permission.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Models
{
    /// <summary>
    /// Represents a permission in the system.
    /// </summary>
    public class Permission
    {
        /// <summary>
        /// Gets or sets the unique identifier for the permission.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the permission (e.g., "ViewOrders").
        /// </summary>
        public string Name { get; set; } // ex: "ViewOrders"

        /// <summary>
        /// Gets or sets the description of the permission.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the collection of role-permission relationships associated with this permission.
        /// </summary>
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
