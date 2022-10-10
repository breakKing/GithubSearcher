using System;
using GithubSearcherTest.Application.Common.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace GithubSearcherTest.Infrastructure.External;

public static class ExternalDependencyInjection
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddHttpClient("Github", httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://api.github.com/");

            httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add(
                HeaderNames.UserAgent, "GithubSearcherTest");
        });
        services.AddTransient<IGithubClient, GithubClient>();

        return services;
    }
}
