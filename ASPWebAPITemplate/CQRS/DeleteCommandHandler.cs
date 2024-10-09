// <copyright file="DeleteCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.CQRSModel
{
    using ASPWebAPITemplate.Repository;
    using MediatR;

#pragma warning disable SA1600
    public class DeleteCommandHandler : IRequestHandler<DeleteRequest, DeleteResponse>
    {
        private readonly ToDoMsSqlDbRepository repository;

        public DeleteCommandHandler(ToDoMsSqlDbRepository repository) => this.repository = repository;

        public async Task<DeleteResponse> Handle(DeleteRequest request, CancellationToken cancellationToken)
        {
            return new DeleteResponse()
            {
                Result = await this.repository.DeleteAsync(request.Id!),
            };
        }
    }
#pragma warning restore SA1600
}
