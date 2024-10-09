// <copyright file="GetRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.CQRSModel
{
     using MediatR;
#pragma warning disable SA1600

     public class GetRequest : IRequest<GetResponse>
    {
        public string? Id { get; set; }
    }
#pragma warning restore SA1600

}
