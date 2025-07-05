// <copyright file="RolePermission.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaplenouApi.Models
{
    /// <summary>
    /// Represents the permissions assigned to a role.
    /// </summary>
    public class RolePermission
    {
        /// <summary>
        /// Gets or sets the unique identifier for the role permission.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the role.
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Gets or sets the application role associated with this permission.
        /// </summary>
        public ApplicationRole Role { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the permission.
        /// </summary>
        public Guid PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the permission associated with this role.
        /// </summary>
        public Permission Permission { get; set; }
    }
}
