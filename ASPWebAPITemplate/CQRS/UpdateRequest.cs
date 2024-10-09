﻿// <copyright file="UpdateRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.CQRSModel
{
    using ASPWebAPITemplate.Models;
    using MediatR;

#pragma warning disable SA1600
    public class UpdateRequest : IRequest<UpdateResponse>
    {
        public ToDoTask? Task { get; set; } = new();
    }
#pragma warning restore SA1600

}
