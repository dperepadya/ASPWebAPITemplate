// <copyright file="AddRequestHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.CQRSModel
{
    using ASPWebAPITemplate.Repository;
    using MediatR;

#pragma warning disable SA1600
    public class AddRequestHandler : IRequestHandler<AddRequest, AddResponse>
    {
        private readonly ToDoMsSqlDbRepository repository;

        public AddRequestHandler(ToDoMsSqlDbRepository repository) => this.repository = repository;

        public async Task<AddResponse> Handle(AddRequest request, CancellationToken cancellationToken)
        {
            return new AddResponse()
            {
                Result = await this.repository.AddAsync(request.Task!),
            };
        }
    }

#pragma warning restore SA1600
}
