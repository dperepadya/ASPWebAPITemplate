// <copyright file="EndpointRouteBuilderExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Extensions
{
    using HealthChecks.UI.Client;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;

#pragma warning disable SA1600
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapHealthChecks(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("health/startup", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            });

            endpoints.MapHealthChecks("health/liveness", new HealthCheckOptions
            {
                Predicate = _ => false,
            });

            endpoints.MapHealthChecks("health/readiness", new HealthCheckOptions
            {
                Predicate = f => f.Tags.Contains("readiness"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            });
            return endpoints;
        }
    }
#pragma warning restore SA1600
}
