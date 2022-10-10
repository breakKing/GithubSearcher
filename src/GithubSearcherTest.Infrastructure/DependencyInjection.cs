using System;
using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Infrastructure.External;
using GithubSearcherTest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace GithubSearcherTest.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(o =>
                o.UseNpgsql(configuration.GetConnectionString("Database")));

            services.AddScoped<IAppDbContext, AppDbContext>();

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
}
