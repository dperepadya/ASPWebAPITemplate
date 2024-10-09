// <copyright file="ErrorsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Controllers
{
    using System.Diagnostics;
    using ASPWebAPITemplate.Exceptions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

#pragma warning disable SA1600

    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public IResult HandleErrorDev()
        {
            var exception = this.HttpContext.Features.Get<IExceptionHandlerPathFeature>()!.Error;
            IResult result = exception switch
            {
                IsNullOrEmptyException isNulOrEmpty => Results.Problem(statusCode: 400, title: $"{isNulOrEmpty.EntityName} {isNulOrEmpty.Message}", extensions: new Dictionary<string, object?> { { "trace-id", Activity.Current?.Id } }),
                NotFoundException notFound => Results.Problem(statusCode: 404, title: $"{notFound.EntityName} {notFound.Message}", extensions: new Dictionary<string, object?> { { "trace-id", Activity.Current?.Id } }),
                AuthenticationException authError => Results.Problem(statusCode: 403, title: $"{authError.EntityName} {authError.Message}", extensions: new Dictionary<string, object?> { { "trace-id", Activity.Current?.Id } }),
                RepositoryAccessException accessError => Results.Problem(statusCode: 400, title: $"{accessError.EntityName} {accessError.Message}", extensions: new Dictionary<string, object?> { { "trace-id", Activity.Current?.Id } }),
                _ => Results.Problem(statusCode: 500, title: exception.Message, extensions: new Dictionary<string, object?> { { "trace-id", Activity.Current?.Id } }),
            };

            return result;
         }
    }
#pragma warning restore SA1600
}
