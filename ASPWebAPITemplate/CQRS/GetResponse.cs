// <copyright file="GetResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.CQRSModel
{
    using ASPWebAPITemplate.Models;

#pragma warning disable SA1600
    public class GetResponse
    {
        public ToDoTask? Task { get; set; }
    }
#pragma warning restore SA1600
}
