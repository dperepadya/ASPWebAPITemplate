// <copyright file="GetRequestHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.CQRSModel
{
    using ASPWebAPITemplate.Repository;
    using MediatR;

#pragma warning disable SA1600
    public class GetRequestHandler : IRequestHandler<GetRequest, GetResponse>
    {
        private readonly ToDoMsSqlDbRepository repository;

        public GetRequestHandler(ToDoMsSqlDbRepository repository) => this.repository = repository;

        public async Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
        {
            return new GetResponse()
            {
                Task = await this.repository.GetAsync(request.Id!),
            };
        }
    }
#pragma warning restore SA1600
}
