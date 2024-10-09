// <copyright file="IAuthService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.JWT
{
    using ASPWebAPITemplate.Models;

#pragma warning disable SA1600

    public interface IAuthService
    {
        string TryToLogin(User users);
    }
#pragma warning restore SA1600
}
