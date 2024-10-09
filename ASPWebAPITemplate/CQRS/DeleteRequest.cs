// <copyright file="DeleteRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.CQRSModel
{
    using MediatR;

#pragma warning disable SA1600
    public class DeleteRequest : IRequest<DeleteResponse>
    {
        public string? Id { get; set; }
    }
#pragma warning restore SA1600

}
