// <copyright file="UserType.cs" company="Maplenou">
// Copyright © Maplenou 2025
// </copyright>

namespace MaplenouApi.Models.Enums
{
    /// <summary>
    /// Specifies the types of users in the system.
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// Represents a customer user.
        /// </summary>
        Customer,

        /// <summary>
        /// Represents a manager user.
        /// </summary>
        Manager,

        /// <summary>
        /// Represents a super administrator user.
        /// </summary>
        SuperAdmin,
    }
}
