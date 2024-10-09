// <copyright file="GetAllResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.CQRSModel
{
    using ASPWebAPITemplate.Models;

#pragma warning disable SA1600
    public class GetAllResponse// : IRequest<Task>
    {
        public List<ToDoTask>? Tasks { get; set; }
    }
#pragma warning restore SA1600
}
