using GithubSearcherTest.Application;
using GithubSearcherTest.Infrastructure;

namespace GithubSearcherTest.Web;

public static class Startup
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        
        builder.Services.AddInfrastructureServices(
            builder.Configuration,
            builder.Environment);
            
        builder.Services.AddWebServices(builder.Configuration);

        return builder;
    }

    public static WebApplication Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseFastEndpoints();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });

        return app;
    }
}
