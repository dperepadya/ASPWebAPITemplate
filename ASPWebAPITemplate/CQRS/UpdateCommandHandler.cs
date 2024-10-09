// <copyright file="UpdateCommandHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.CQRSModel
{
    using ASPWebAPITemplate.Repository;
    using MediatR;

#pragma warning disable SA1600
    public class UpdateCommandHandler : IRequestHandler<UpdateRequest, UpdateResponse>
    {
        private readonly ToDoMsSqlDbRepository repository;

        public UpdateCommandHandler(ToDoMsSqlDbRepository repository) => this.repository = repository;

        public async Task<UpdateResponse> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            return new UpdateResponse()
            {
                Result = await this.repository.UpdateAsync(request.Task!),
            };
        }
    }
#pragma warning restore SA1600
}
