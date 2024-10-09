// <copyright file="GetAllRequestHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.CQRSModel
{
    using ASPWebAPITemplate.Repository;
    using MediatR;

#pragma warning disable SA1600

    public class GetAllRequestHandler : IRequestHandler<GetAllRequest, GetAllResponse>
    {
        private readonly ToDoMsSqlDbRepository repository;

        public GetAllRequestHandler(ToDoMsSqlDbRepository repository) => this.repository = repository;

        public async Task<GetAllResponse> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            var tasks = await this.repository.GetAllAsync();
            return new GetAllResponse()
            {
                Tasks = tasks,
            };
        }
    }

#pragma warning restore SA1600
}
